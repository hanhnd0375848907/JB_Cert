using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoleModel
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public List<ClaimModel> ClaimModels {get;set;}

        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return this.RoleDescription;
        }
    }
}
