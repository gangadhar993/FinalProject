using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

    public class StudentTerm
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentTermID { get; internal set; }
        public int DegreePlanId { get; internal set; }
        public DegreePlan DegreePlan { get; set; }
        public int Term { get; internal set; }
        public string TermAbbrev { get; internal set; }
        public string TermName { get; internal set; }
        public bool Done { get; set; }

        public System.Collections.Generic.ICollection<Slot> Slots { get; set; }

    public override string ToString()
    {
        return base.ToString() + ": " +
          "StudentTermID = " + StudentTermID +
          "DegreePlanId = " + DegreePlanId +
          ", Term = " + Term +
          ", TermAbbrev = " + TermAbbrev +
          ", DegreePlan = {" + DegreePlan.ToString() +
                       "}";
    }
}

