using System;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Summary description for Credit
/// </summary>
public class Credit
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int CreditID { get; set; }
    public string CreditAbbrev { get; set; }
    public string CreditName { get; set; }
    public int IsSummer{ get; set; }
    public int IsSpring { get; set; }
    public int IsFall { get; set; }
    public bool Done { get; set; }

    public System.Collections.Generic.ICollection<DegreeCredit> DegreeCredits { get; set; }
    public override string ToString()
    {
        return base.ToString() + ": " +
          "CreditID = " + CreditID +
          "CreditAbbrev = " + CreditAbbrev +
          "CreditName = " + CreditName;
      ;
    }
}
