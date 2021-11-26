using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication27.Models
{
    public class MyBlog
    {
        [Key]
        public int  Id {get;set; }
       
        [Display(Name = "Название (заголовок)")]
        public string NameBlog { get; set; }
       
        [Display(Name = "Полное описание")]
        public string TextField { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }


    }
}