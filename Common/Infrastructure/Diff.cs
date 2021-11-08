using System;

namespace Common.Infrastructure
{
    public interface Diff
    {
        DiffType GetType();

        LineItem GetNewValue();
    }
}