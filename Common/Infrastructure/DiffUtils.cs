using Common.Domain.Model;
using System;

namespace Common.Infrastructure
{
    internal class DiffUtils
    {
        public static EntityDiff Diff<T, ID>(T snapshot, T aggregate)
            where T : Aggregate<ID>
            where ID : IDentifier
        {
            throw new NotImplementedException();
        }
    }
}