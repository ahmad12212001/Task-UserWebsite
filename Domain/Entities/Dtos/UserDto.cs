namespace Application.Users.Command.Dtos
{

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Add { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Number { get; set; } = null!;
    }
}
