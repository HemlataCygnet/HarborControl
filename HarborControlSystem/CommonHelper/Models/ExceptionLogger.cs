namespace UI.Models
{
    public class ExceptionLogger
    {
        
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string InnerException { get; set; }
        public string LogTime { get; set; }
    }
}