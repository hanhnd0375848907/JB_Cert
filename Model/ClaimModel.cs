using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClaimModel
    {
        public int Id { get; set; }

        public string ClaimName { get; set; }

        public string ClaimDescription { get; set; }

        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return this.ClaimDescription;
        }
    }
}
