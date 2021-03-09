using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibrary.Models
{
    public class BookReserve
    {
        public int Reserve_ID { get; set; }
        public int Book_ID { get; set; }
        public int User_ID { get; set; }
        public string Book_Name { get; set; }
    }
}