using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public class DbContext<T, ID> where T : Aggregate<ID> where ID : IDentifier
    {
        private Dictionary<ID, T> aggregateMap = new Dictionary<ID, T>();
        public void Attach(T aggregate)
        {
            if (aggregate.GetId() != null) { if (!aggregateMap.ContainsKey(aggregate.GetId())) { this.Merge(aggregate); } }
        }

        public void Detach(T aggregate) { if (aggregate.GetId() != null) { aggregateMap.Remove(aggregate.GetId()); } }

        public EntityDiff DetectChanges(T aggregate)
        {
            if (aggregate.GetId() == null)
            {
                return EntityDiff.EMPTY;
            }

            T snapshot = aggregateMap[aggregate.GetId()];

            if (snapshot == null)
            {
                Attach(aggregate);
            }

            return DiffUtils.Diff<T, ID>(snapshot, aggregate);
        }

        public T Find(ID id) { return aggregateMap[id]; }

        public void Merge(T aggregate)
        {
            if (aggregate.GetId() != null)
            {
                T snapshot = SnapshotUtils.Snapshot<T, ID>(aggregate);
                aggregateMap.Add(aggregate.GetId(), snapshot);
            }
        }

        public void SetId(T aggregate, ID id) { ReflectionUtils.WriteField("id", aggregate, id); }
    }


}
