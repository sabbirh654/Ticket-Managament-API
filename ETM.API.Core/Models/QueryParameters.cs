using System.ComponentModel.DataAnnotations;

namespace ETM.API.Core.Models
{
    public class QueryParameters
    {
        const int MAX_PAGE_SIZE = 50;

        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
            }
        }

        public int[]? UserIds { get; set; }
        public int[]? DepartmentIds { get; set; }
        public int[]? StatusIds { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [Required]
        public bool IsAllowSorting { get; set; } = false;
        public bool IsAscendingOrder { get; set; } = true;

    }
}
