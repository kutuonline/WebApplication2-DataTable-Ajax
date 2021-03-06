//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class mahasiswa
    {
        [Key]
        public int nip { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string nm_mhs { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Alamat is required.")]
        public string alamat { get; set; }
    }
}
