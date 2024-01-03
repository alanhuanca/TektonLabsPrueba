namespace Tekton.Api.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeErrorException : CodeErrorResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Details { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public CodeErrorException(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
