using Alza_API.Interfaces.Models;
using System.ComponentModel;

namespace Alza_API.Models
{
#nullable enable
    /// <summary>
    /// Footer with paging
    /// </summary>
    public class Footer : IFooter
    {
        /// <summary>
        /// Number of products per page (default 10)
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Page number (default 1)
        /// </summary>
        public int? PageNumber { get; set; } = default;
    }
}
