using Common.Domain.Model;
using System;

namespace Common.Infrastructure
{
    internal class SnapshotUtils
    {
        internal static T Snapshot<T, ID>(T aggregate)
            where T : Aggregate<ID>
            where ID : IDentifier
        {
            throw new NotImplementedException();
        }
    }
}