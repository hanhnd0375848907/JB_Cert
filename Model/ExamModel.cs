using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ExamModel
    {
        public int Id { get; set; }

        public string ExamName { get; set; }

        public DateTime ExamDate { get; set; }

        public int BlankCertTypeId { get; set; }

        public string BlankCertTypeName { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
