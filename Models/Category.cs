using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticasCRUD.Models
{
    public class Category
    {
        public Category() { }
        public Category(int id,String name,String description) { 
            this.CategoryID = id;
            this.CategoryName = name;
            this.Description = description; 
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}