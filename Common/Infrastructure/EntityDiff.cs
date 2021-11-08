using System;

namespace Common.Infrastructure
{
    public class EntityDiff
    {
        public static EntityDiff EMPTY { get; internal set; }

        public bool IsSelfModified()
        {
            throw new NotImplementedException();
        }

        internal bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public Diff GetDiff(string v)
        {
            throw new NotImplementedException();
        }
    }
}