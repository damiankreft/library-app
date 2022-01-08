using System.Collections.Generic;

#nullable disable

namespace LibraryService.Core.Domain
{
    public partial class Account
    {
        public Account()
        {
            Leases = new HashSet<Lease>();
        }

        public Account(string lastname, string firstname, string email, string password, string salt)
        {
            Lastname = lastname;
            Firstname = firstname;
            Email = email;
            Password = password;
            Salt = salt;
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public uint? LeaseCounter { get; set; }
        public string Email { get; set; }
        public float? Rating { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }

        public virtual Librarian Librarian { get; set; }
        public virtual ICollection<Lease> Leases { get; set; }
    }
}
