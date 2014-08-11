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
    
    public partial class Client
    {
        public Client()
        {
            this.Bill = new HashSet<Bill>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage= "The Client Name is required!!!"), MinLength(2,ErrorMessage="* The Name has to contain more than two letters!!!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The first Last Name is required!!!"), MinLength(2, ErrorMessage = "* The first Last Name has to contain more than two letters!!!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Characters.")]
        public string Lastname1 { get; set; }

        [Required(ErrorMessage = "Last second Last Name is required!!!"), MinLength(2, ErrorMessage = "* The second Last Name has to contain more than two letters!!!")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Invalid Characters.")]
        public string Lastname2 { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = " The Phone number is required!!!- Only numbers are allowed in this field!!!")]
        [RegularExpression(@"^[0-9]{8,8}", ErrorMessage = "Required  8 numeric digits.")]
        public Nullable<int> Telephone { get; set; }
    
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
