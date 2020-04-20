using EARGE.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EARGE.BusinessLayer {
    public class BaseManager {
        public earge_teamDb _db = new DataLayer.earge_teamDb();
    }
}
