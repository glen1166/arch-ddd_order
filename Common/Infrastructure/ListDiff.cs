using System.Collections;

namespace Common.Infrastructure
{
    public class ListDiff : Diff, IEnumerable
    {
        public LineItem GetNewValue()
        {
            throw new System.NotImplementedException();
        }

        DiffType Diff.GetType()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}