namespace Escola.Models
{
    public class Result
    {
        public string Error { get; set; }
        public string Token { get; set; }
        public bool Success { get; set; }
        public StudentModel Student { get; set; }
        public UserModel User { get; set; }
    }
}