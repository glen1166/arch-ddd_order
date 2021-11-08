using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public interface Repository<T, ID> where T : Aggregate<ID> where ID : IDentifier
    {
        void Attach(T aggregate);
        /**     * 解除一个Aggregate的追踪     * Change-Tracking在下文会讲，非必须     */
        void Detach(T aggregate);
        /**     * 通过ID寻找Aggregate。     * 找到的Aggregate自动是可追踪的     */
        T Find(ID id);
        /**     * 将一个Aggregate从Repository移除     * 操作后的aggregate对象自动取消追踪     */
        void Remove(T aggregate);
        /**     * 保存一个Aggregate     * 保存后自动重置追踪条件     */
        void Save(T aggregate);
    }

}

