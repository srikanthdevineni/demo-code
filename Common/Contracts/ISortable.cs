using System;
namespace Common.Contracts
{
    public interface ISortable<T>
    {
        Func<T, object> FetchPropDelegate(string propName);
    }
}
