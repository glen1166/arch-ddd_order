using Common.Domain.Model;
using SCM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Infrastructure
{
    // 代码在Infrastructure层@Repository // Spring的注解
    public class _OrderRepositoryImpl : OrderRepository
    {
        private OrderDAO dao;
        // 具体的DAO接口
        private OrderDataConverter converter; // 转化器
        public _OrderRepositoryImpl(OrderDAO dao)
        {
            this.dao = dao; 
            this.converter = OrderDataConverter.INSTANCE;
        }
        public Order Find(OrderId orderId)
        {
            OrderDO orderDO = dao.FindById(orderId.GetValue());
            return converter.FromData(orderDO);
        }
        public void Remove(Order aggregate)
        {
            OrderDO orderDO = converter.ToData(aggregate);
            dao.Delete(orderDO);
        }

        public void Save(Order aggregate)
        {
            if (aggregate.GetId() != null && aggregate.GetId().GetValue() > 0)
            {
                // update
                OrderDO orderDO = converter.ToData(aggregate);
                dao.Update(orderDO);
            }
            else
            {
                // insert
                OrderDO orderDO = converter.ToData(aggregate);
                dao.Insert(orderDO);
                aggregate.SetId(converter.FromData(orderDO).GetId());
            }

        }

        public Page<Order, OrderId> Query(OrderQuery query)
        {
            List<OrderDO> orderDOS = dao.QueryPaged(query);
            long count = dao.Count(query);
            List<Order> result = orderDOS.Select(order => converter.FromData(order)).ToList();
            return Page<Order, OrderId>.With(result, query, count);
        }

        public Order FindInStore(OrderId id, StoreId storeId)
        {
            OrderDO orderDO = dao.FindInStore(id.GetValue(), storeId.GetValue());
            return converter.FromData(orderDO);
        }

        public long Count(OrderQuery query)
        {
            throw new NotImplementedException();
        }

        public void Attach(Order aggregate)
        {
            throw new NotImplementedException();
        }

        public void Detach(Order aggregate)
        {
            throw new NotImplementedException();
        }
    }


}
