using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Slot
/// </summary>
public class Slot
{



    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int SlotID { get; set; }
    [Required]
    public int StudentTermID { get; internal set; }
    [ForeignKey("StudentTermID")]
    public StudentTerm StudentTerm { get; set; }
    public int Term { get; set; }
    public int DegreeCreditID { get; set; }
    public DegreeCredit DegreeCredit { get; set; }
    public char Status { get; set; }
    public bool Done { get; set; }
    public override string ToString()
    {


        return base.ToString() + ": " +
          "SlotID = " + SlotID +
          "StudentTermID = " + StudentTermID +
          ", Term = " + Term +
          ", DegreeCreditID = " + DegreeCreditID +
          ", StudentTerm = {" + StudentTerm.ToString() +
            "}, DegreeCredit = {" + DegreeCredit.ToString() +
        "}";
    }


}
