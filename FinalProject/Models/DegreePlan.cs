using System;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DegreePlan
{

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DegreePlanID { get; set; }
    public int StudentID { get; set; }
    [ForeignKey("StudentID")]
    public Student Student { get; set; }
    public string DegreeAbbrev { get; set; }
    public string DegreePlanName { get; set; }
    public int DegreeID { get; set; }
    [ForeignKey("DegreeID")]
    public Degree Degree { get; set; }
    public string String { get; set; }
    public string DegreePlanAbbrev { get; internal set; }
    public string DereePlanName { get; internal set; }
}
