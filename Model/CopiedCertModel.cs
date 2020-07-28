using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CopiedCertModel
    {
        public int Id { get; set; }

        public int CertId { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int RankingId { get; set; }

        public string RankingName { get; set; }

        public string CertName { get; set; }

        public int BlankCertId { get; set; }

        public string Serial { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public string CopiedReferenceNumber { get; set; }

        public string ProviderName { get; set; }

        public string Position { get; set; }

        public DateTime GrantedDate { get; set; }

        public string GrantedAddress { get; set; }

        public string ManagementAddress { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverIdentityNumber { get; set; }

        public string Note { get; set; }

        public int PrintedNumber { get; set; }

        public int GrantedNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}
