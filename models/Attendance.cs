using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    public class Attendance
    {
        public int Id { get; set; }
        public int SportsmanId { get; set; }
        public int CoachId { get; set; }
        public DateTime TrainingDate { get; set; }
        public bool Attended { get; set; }

        public string SportsmanName { get; set; } // для отображения в отчётах
        public string ParentPhone { get; set; }
        public string CoachName { get; set; }
        public string SportType { get; set; }
    }
}
