using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.Utilities.Pagination
{
    public class PagedResponseViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "PageIndex must be greater than 0")]
        public int PageIndex { get; set; }

        public int PageTotal { get; set; }

        public int PageSkip => (PageIndex - 1) * PageSize;

        [Range(1, int.MaxValue, ErrorMessage = "PageSize must be greater than 0")]
        public int PageSize { get; set; }

        public string Filter { get; set; }

        public string Keyword { get; set; }
    }
}
