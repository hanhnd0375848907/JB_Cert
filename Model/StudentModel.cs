using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentModel
    {
        public int Id { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public int EthnicId { get; set; }

        public string EthnicName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime Dob { get; set; }

        public string BornedAddress { get; set; }
        
        public string HouseHold { get; set; }

        public string IdentityNumber { get; set; }

        public string Gender { get; set; }
        
        public string Image { get; set; }

        public float Score { get; set; }

        public int BlankCertTypeId { get; set; }

        public string BlankCertTypeName { get; set; }

        public int GraduatingYear { get; set; }

        public int LearningModeId { get; set; }

        public string LearningModeName { get; set; }

        public int MajorId { get; set; }

        public string MajorName { get; set; }

        public string Note { get; set; }

        public int RankingId { get; set; }

        public string RankingName { get; set; }

        public int CertId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
