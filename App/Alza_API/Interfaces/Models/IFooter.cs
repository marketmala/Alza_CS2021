namespace Alza_API.Interfaces.Models
{
#nullable enable
    /// <summary>
    /// Footer Interface
    /// </summary>
    public interface IFooter
    {
        /// <summary>
        /// Number of products per page (default 10)
        /// </summary>
        int? PageSize { get; set; }
        /// <summary>
        /// Page number (default 1)
        /// </summary>
        int? PageNumber { get; set; }
    }
}
