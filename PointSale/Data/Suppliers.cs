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
    
    public partial class Suppliers
    {
        public Suppliers()
        {
            this.ProductSuppliers = new HashSet<ProductSuppliers>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "The Supplier Name is required!!!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = " The Phone number is required!!!- Only numbers are allowed in this field!!!")]
        [RegularExpression(@"^[0-9]{8,8}", ErrorMessage = "Required  8 numeric digits.")]
        public Nullable<int> Telephone { get; set; }

        [Required(ErrorMessage = "The Address is required!!!")]
        public string Address { get; set; }

        public string Detail { get; set; }
    
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; }
    }
}
