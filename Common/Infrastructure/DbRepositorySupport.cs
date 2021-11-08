using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    // 这个类是一个通用的支撑类，为了减少开发者的重复劳动。在用的时候需要继承这个类
    public abstract class DbRepositorySupport<T, ID> : Repository<T, ID> where T : Aggregate<ID> where ID : IDentifier
    {
        // 让AggregateManager去维护Snapshot    (AccessLevel.PROTECTED)
        private AggregateManager<T, ID> aggregateManager;
        protected DbRepositorySupport()
        {
            this.aggregateManager = new ThreadLocalAggregateManager<T, ID>();
        }

        /**     * 这几个方法是继承的子类应该去实现的     */
        protected abstract void OnInsert(T aggregate);
        protected abstract T OnSelect(ID id);
        protected abstract void OnUpdate(T aggregate, EntityDiff diff);
        protected abstract void OnDelete(T aggregate);
        /**     * Attach的操作就是让Aggregate可以被追踪     */
        public void Attach(T aggregate) { this.aggregateManager.Attach(aggregate); }
        /**     * Detach的操作就是让Aggregate停止追踪     */
        public void Detach(T aggregate) { this.aggregateManager.Detach(aggregate); }
        public T Find(ID id)
        {
            T aggregate = this.OnSelect(id); if (aggregate != null)
            {
                // 这里的就是让查询出来的对象能够被追踪。            
                // 如果自己实现了一个定制查询接口，要记得单独调用attach。
                this.Attach(aggregate);
            }

            return aggregate;
        }

        public void Remove(T aggregate)
        {
            this.OnDelete(aggregate);        // 删除停止追踪
            this.Detach(aggregate);
        }

        public void Save(T aggregate)
        {        // 如果没有ID，直接插入
            if (aggregate.GetId() == null)
            {
                this.OnInsert(aggregate);
                this.Attach(aggregate);
                return;
            }
            // 做Diff
            EntityDiff diff = aggregateManager.DetectChanges(aggregate);
            if (diff.IsEmpty()) { return; }
            // 调用UPDATE
            this.OnUpdate(aggregate, diff);
            // 最终将DB带来的变化更新回AggregateManager
            aggregateManager.Merge(aggregate);
        }
    }
}
