//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data2
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillDetail
    {
        public int Bill { get; set; }
        public Nullable<int> Code { get; set; }
        public Nullable<int> Product { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> UnitCost { get; set; }
    
        public virtual Bill Bill1 { get; set; }
    }
}
