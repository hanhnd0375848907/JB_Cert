using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BlankCertConfigModel
    {
        public int Id { get; set; }
        public int SchoolX { get; set; }
        public int SchoolY { get; set; }
        public int FullNameX { get; set; }
        public int FullNameY { get; set; }
        public int GenderX { get; set; }
        public int GenderY { get; set; }
        public int DobX { get; set; }
        public int DobY { get; set; }
        public int BornedAddressX { get; set; }
        public int BornedAddressY { get; set; }
        public int MajorX { get; set; }
        public int MajorY { get; set; }
        public int RankingX { get; set; }
        public int RankingY { get; set; }
        public int LearningModeX { get; set; }
        public int LearningModeY { get; set; }
        public int SerialX { get; set; }
        public int SerialY { get; set; }
        public int ReferenceNumberX { get; set; }
        public int ReferenceNumberY { get; set; }
        public int CreatedDateX { get; set; }
        public int CreatedDateY { get; set; }
        public int ExamX { get; set; }
        public int ExamY { get; set; }
        public int EthnicX { get; set; }
        public int EthnicY { get; set; }
        public int ScoreX { get; set; }
        public int ScoreY { get; set; }
        public int BlankCertTypeId { get; set; }
        public string BlankCertTypeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
    }
}
