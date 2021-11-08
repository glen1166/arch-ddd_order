using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    interface AggregateManager<T, ID> where T : Aggregate<ID> where ID : IDentifier
    {
        void Attach(T aggregate);
        void Attach(T aggregate, ID id);
        void Detach(T aggregate);
        T Find(ID id);
        EntityDiff DetectChanges(T aggregate);
        void Merge(T aggregate);
    }
}
