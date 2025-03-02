namespace Curriculos.Models
{
    public class Curriculum
    {
        public int Id { get; set; } = new Random().Next();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Formation { get; set; } = string.Empty;
        public int PhoneNumber { get; set; } = 0;
    }
}
