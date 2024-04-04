namespace NTierExample.DTO.UserDtos
{
    public class UserCreateDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate => DateTime.Now;
    }
}
