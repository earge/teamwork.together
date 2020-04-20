using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using EARGE.DataLayer;

namespace EARGE.BusinessLayer.CommonManager {
    public class LoginManager : BaseManager {
        public TeamMember Login(string email, string password) {
            return _db.TeamMembers.Where(x => x.Email == email.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}
