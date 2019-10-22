using System.Linq;
using DodBenchmark.OOP;

namespace DodBenchmark.DOD {
    public class Users {
        public int[] ids;

        public string[] guids;
        
        public string[] logins;

        public string[] emails;

        public static Users From(User[] users) {
            return new Users() {
                ids = users.Select(x => x.id).ToArray(),
                logins = users.Select(x => x.login).ToArray(),
                emails = users.Select(x => x.email).ToArray(),
                guids = users.Select(x => x.guid).ToArray()
            };
        }
    }
}