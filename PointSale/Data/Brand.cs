//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Brand
    {
        public Brand()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "The Brand Name is required!!!")]
        public string Name { get; set; }
    
        public virtual ICollection<Products> Products { get; set; }
    }
}
