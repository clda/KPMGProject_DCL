using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstKPMG_Project.Models
{
    public class MetaData_tblUserLoginDetails
    {
        public int iUserId { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string vchUserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password cannot be empty")]
        public string vchUserPassword { get; set; }

        public string vchUserRole { get; set; }

        
    }

    [MetadataType(typeof(MetaData_tblUserLoginDetails))]
    public partial class tblUserLoginDetail
    {

    }
}