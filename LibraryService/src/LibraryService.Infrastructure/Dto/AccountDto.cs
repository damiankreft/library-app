namespace LibraryService.Infrastructure.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }

        public AccountDto() { }
      
        public AccountDto(int id, string lastname, string firstname, string email)
        {
            Id = id;
            Lastname = lastname;
            Firstname = firstname;
            Email = email;
        }
    }
}