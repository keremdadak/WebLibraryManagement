//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebLibrary.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Users
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Surname { get; set; }
        public string User_Mail { get; set; }
        public string User_Password { get; set; }
        public string User_PhoneNumber { get; set; }
        public string User_Adress { get; set; }
        public Nullable<byte> User_Type { get; set; }
        public Nullable<int> Book_ID { get; set; }
    }
}
