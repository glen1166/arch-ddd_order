using System;
using System.Collections.Generic;

namespace Common.Domain.Model
{
    public class Page<T, ID> where T : Aggregate<ID> where ID : IDentifier
    {
        public static Page<T, ID> With(List<T> result, IQuery query, long count)
        {
            throw new NotImplementedException();
        }
    }
}