using SCM.Domain.Model;
using System;

namespace SCM.Infrastructure
{
    internal class OrderDataConverter
    {
        public static OrderDataConverter INSTANCE { get; internal set; }

        internal Order FromData(OrderDO orderDO)
        {
            throw new NotImplementedException();
        }

        internal OrderDO ToData(Order aggregate)
        {
            throw new NotImplementedException();
        }
    }
}