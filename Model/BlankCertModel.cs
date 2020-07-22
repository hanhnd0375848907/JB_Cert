using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BlankCertModel
    {
        public int Id { get; set; }

        public string Serial { get; set; }

        public string ReferenceNumber { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsReturned { get; set; }

        public string ReasonReturn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Image { get; set; }

        public int BlankCertTypeId { get; set; }

        public string BlankCertTypeName { get; set; }
    }
}
