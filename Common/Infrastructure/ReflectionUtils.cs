using Common.Domain.Model;
using System;

namespace Common.Infrastructure
{
    internal class ReflectionUtils
    {
        internal static void WriteField<T, ID>(string v, T aggregate, ID id)
            where T : Aggregate<ID>
            where ID : IDentifier
        {
            throw new NotImplementedException();
        }
    }
}