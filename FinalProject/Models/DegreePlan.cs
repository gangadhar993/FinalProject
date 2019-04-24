using System;
using System.Collections.Generic;
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
    public string DegreePlanAbbrev { get; set; }
    public string DegreePlanName { get; set; }
    public int DegreeID { get; set; }
    [ForeignKey("DegreeID")]
    public Degree Degree { get; set; }\


    public bool Done { get; set; }

    //changed plan structure

    public System.Collections.Generic.ICollection<StudentTerm> StudentTerms { get; set; }
    public override string ToString()
    {
        return base.ToString() + ": " +
          "DegreePlanID = " + DegreePlanID +
          "StudentId = " + StudentID +
          ", DegreeID = " + DegreeID +
          ", DegreePlanAbbrev = " + DegreePlanAbbrev +
          ", DegreePlanName = " + DegreePlanName +
          ", Student ={" + Student.ToString() +
                        "}, Degree = {" + Degree.ToString() +
                       "}";
    }
}
