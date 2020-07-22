using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TownModel
    {
        public int Id { get; set; }

        public string TownName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Fax { get; set; }

        public string Note { get; set; }

        public bool IsDeleted { get; set; }
    }
}
