using System;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Slot
/// </summary>
public class DegreeCredit
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DegreeCreditID { get; set; }
    public int DegreeID { get; set; }
    [ForeignKey("DegreeID")]
    public Degree Degree { get; set; }
    public int CreditID { get; set; }
    [ForeignKey("CreditID")]
    public Credit Credit { get; set; }
    public bool Done { get; set; }
}