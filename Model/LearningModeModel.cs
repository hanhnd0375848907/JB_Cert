using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LearningModeModel
    {
        public int Id { get; set; }

        public string LearningModeName { get; set; }

        public string Note { get; set; }

        public bool IsDeleted { get; set; }
    }
}
