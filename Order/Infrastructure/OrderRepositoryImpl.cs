using Common.Domain.Model;
using Common.Infrastructure;
using SCM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Infrastructure
{
    public class OrderRepositoryImpl : DbRepositorySupport<Order, OrderId>, OrderRepository
    {
        private OrderDAO orderDAO;
        private LineItemDAO lineItemDAO;
        private OrderDataConverter converter;
        private LineItemDataConverter lineItemConverter;

        public long Count(OrderQuery query)
        {
            throw new NotImplementedException();
        }

        public Order FindInStore(OrderId id, StoreId storeId)
        {
            throw new NotImplementedException();
        }

        public Page<Order, OrderId> Query(OrderQuery query)
        {
            throw new NotImplementedException();
        }

        protected override void OnDelete(Order aggregate)
        {
            throw new NotImplementedException();
        }

        protected override void OnInsert(Order aggregate)
        {
            throw new NotImplementedException();
        }

        protected override Order OnSelect(OrderId id)
        {
            throw new NotImplementedException();
        }

        // 部分代码省略，见上文
        protected override void OnUpdate(Order aggregate, EntityDiff diff)
        {
            if (diff.IsSelfModified()) 
            { 
                OrderDO orderDO = converter.ToData(aggregate); 
                orderDAO.Update(orderDO); 
            }
            
            Diff lineItemDiffs = diff.GetDiff("lineItems"); 
            if (lineItemDiffs is ListDiff) 
            { 
                ListDiff diffList = (ListDiff)lineItemDiffs; 
                foreach (Diff itemDiff in diffList) { 
                    if (itemDiff.GetType() == DiffType.Removed) 
                    { 
                        LineItem line = (LineItem)itemDiff.GetNewValue();
                        LineItemDO lineDO = lineItemConverter.ToData(line); 
                        lineItemDAO.Delete(lineDO); 
                    } 
                    if (itemDiff.GetType() == DiffType.Added) 
                    { 
                        LineItem line = (LineItem)itemDiff.GetNewValue(); 
                        LineItemDO lineDO = lineItemConverter.ToData(line); 
                        lineItemDAO.Insert(lineDO); 
                    } 
                    if (itemDiff.GetType() == DiffType.Modified) 
                    { 
                        LineItem line = (LineItem)itemDiff.GetNewValue();
                        LineItemDO lineDO = lineItemConverter.ToData(line); 
                        lineItemDAO.Update(lineDO); }
                } 
            }
        }
    }
}
