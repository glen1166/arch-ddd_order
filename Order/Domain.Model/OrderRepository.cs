using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Domain.Model
{
    public interface OrderRepository : Repository<Order, OrderId> {
        // 自定义Count接口，在这里OrderQuery是一个自定义的DTO
        long Count(OrderQuery query);
        // 自定义分页查询接口
        Page<Order, OrderId> Query(OrderQuery query);
        // 自定义有多个条件的查询接口
        Order FindInStore(OrderId id, StoreId storeId);
    }
}
