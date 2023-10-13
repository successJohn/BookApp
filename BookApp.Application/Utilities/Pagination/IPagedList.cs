using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities.Pagination
{
    public interface IPagedList
    {
        int PageCount { get; }

        int TotalItemCount { get; }

        int PageNumber { get; }

        int PageSize { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>
    {
        T this[int index] { get; }

        int Count { get; }

        IEnumerable<T> Items { get; }

        IPagedList GetMetaData();
    }
}
