using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Domain.Model
{
    public class Order : Aggregate<OrderId>
    {
        public OrderId GetId()
        {
            throw new NotImplementedException();
        }

        internal void SetId(object p)
        {
            throw new NotImplementedException();
        }
    }
}
