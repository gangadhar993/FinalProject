using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Slot
/// </summary>
public class Slot
{

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int SlotID { get; set; }
    public int DegreePlanID { get; set; }
    [ForeignKey("DegreePlanID")]
    public DegreePlan DegreePlan { get; set; }
    public int Term { get; set; }
    public int CreditID { get; set; }
    [ForeignKey("CreditID")]
    public Credit Credit { get; set; }
    public char Status { get; set; }


    public ICollection<Credit> Credits { get; set; }
}
