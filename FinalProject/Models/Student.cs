using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int StudentID { get; set; }
    [Required]
    [StringLength(25)]
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int I919 { get; set; }
    public bool Done { get; set; }

    public System.Collections.Generic.ICollection<DegreePlan> DegreePlans { get; set; }

    public override string ToString()
    {
        return base.ToString() + ": " +
          "StudentID = " + StudentID +
          ", LastName = " + LastName +
          ", FirstName = " + FirstName +
          ",I919 = " + I919 +
          "";
    }
}
