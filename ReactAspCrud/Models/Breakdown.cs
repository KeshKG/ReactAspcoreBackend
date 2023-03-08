using System.ComponentModel.DataAnnotations;

namespace ReactAspCrud.Models
{
    public class Breakdown
    {
        [Key]
        public string BreakdownID { get; set; }
        public string CompName { get; set; }
        public string Drivername { get; set; }

        public string RegNo { get; set; }
        public DateTime BreakDate { get; set; }

    }

}

