using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class Developers
{
    public int Id { get; set; }

    public string Given { get; set; }

    public string Family { get; set; }

    public string GraduationTerm { get; set; }

    public string DesiredPosition { get; set; }

    public string Skills { get; set; }

    public int Rating { get; set; }

    [Display(Name = "Created Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }

}

