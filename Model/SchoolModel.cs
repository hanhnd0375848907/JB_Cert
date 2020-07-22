using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SchoolModel
    {
        public int Id { get; set; }

        public int VillageId { get; set; }

        public string VillageName {get;set;}

        public int TownId { get; set; }

        public string TownName { get; set; }

        public string SchoolName { get; set; }

        public string Representative { get; set; }

        public string Province { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Fax { get; set; }

        public string TrainingMode { get; set; }

        public string Note { get; set; }

        public int BlankCertTypeId { get; set; }

        public string BlankCertTypeName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
