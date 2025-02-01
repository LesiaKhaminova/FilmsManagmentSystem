
namespace BLL.DTO
{
    public class Response
    {
        public bool IsSuccess { get; set; } = true;

        public List<string> ErrorMessages { get; set; } = new List<string>();

        public object Result { get; set; }
    }
}
