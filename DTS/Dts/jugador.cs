//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dts
{
    using System;
    using System.Collections.Generic;
    
    public partial class jugador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public jugador()
        {
            this.partidoes = new HashSet<partido>();
        }
    
        public int jugid { get; set; }
        public string jugnombre { get; set; }
        public System.DateTime jugfechanac { get; set; }
        public string jugsexo { get; set; }
        public string jugposicion { get; set; }
        public string jugreputacion { get; set; }
        public string jugemail { get; set; }
        public string jugcontraseña { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partido> partidoes { get; set; }
    }
}
