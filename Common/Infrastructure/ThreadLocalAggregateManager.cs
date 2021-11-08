using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public class ThreadLocalAggregateManager<T, ID> : AggregateManager<T, ID> where T : Aggregate<ID> where ID : IDentifier
    {
        private ThreadLocal<DbContext<T, ID>> context;
        public ThreadLocalAggregateManager()
        {
            this.context = new ThreadLocal<DbContext<T, ID>>(() => new DbContext<T, ID>());
        }
        public void Attach(T aggregate) { context.Value.Attach(aggregate); }
        public void Attach(T aggregate, ID id) { context.Value.SetId(aggregate, id); context.Value.Attach(aggregate); }
        public void Detach(T aggregate) { context.Value.Detach(aggregate); }
        public T Find(ID id) { return context.Value.Find(id); }
        public EntityDiff DetectChanges(T aggregate) { return context.Value.DetectChanges(aggregate); }
        public void Merge(T aggregate) { context.Value.Merge(aggregate); }
    }
}
