using System;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Degree
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DegreeID { get; set; }
    public string DegreeAbbrev { get; set; }
    public string DegreeName { get; set; }
    public int NumberOFTerms { get; set; }
    public bool Done { get; set; }
    // Add navigation property for each related entity

    // each degree has many requirements... 
    public System.Collections.Generic.ICollection<DegreeCredit> DegreeCredits { get; set; }
    public override string ToString()
    {
        return base.ToString() + ": " +
          "DegreeId = " + DegreeID +
          ", DegreeAbbrev = " + DegreeAbbrev +
          ", DegreeName = " + DegreeName +
          ",NumberOFTerms = "+ NumberOFTerms+
          "";
    }
}
