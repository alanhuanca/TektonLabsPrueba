namespace Tekton.Api.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class CodeErrorResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Request enviado tiene errores",
                401 => "No tienes authorizacion para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se producieron errores en el servidor",
                _ => string.Empty
            };
        }
    }
}
