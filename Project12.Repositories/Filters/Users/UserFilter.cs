using System.Collections.Generic;

namespace Project12.Repositories.Filters.Users
{
    public class UserFilter
    {
        public HashSet<string> Ids { get; set; } = new HashSet<string>();

        public HashSet<string> Usernames { get; set; } = new HashSet<string>();

        public HashSet<string> Emails { get; set; } = new HashSet<string>();
    }
}
