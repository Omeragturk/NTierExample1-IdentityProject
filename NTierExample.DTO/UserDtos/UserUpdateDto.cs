namespace NTierExample.DTO.UserDtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdateDate => DateTime.Now;
    }
}
