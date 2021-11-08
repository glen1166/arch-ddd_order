using Common.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Domain.Model
{
    public class OrderId : IDentifier
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        internal int GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
