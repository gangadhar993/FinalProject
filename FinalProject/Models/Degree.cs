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
   
}
