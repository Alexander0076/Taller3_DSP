//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace La_tiendita.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Ventas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ventas()
        {
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }


        [Display(Name = "Id Ventas")]
        public int Id_venta { get; set; }

        [Display(Name = "Hora de venta")]
        public Nullable<System.TimeSpan> Hora_venta { get; set; }

        [Display(Name = "Fecha de venta")]
        public Nullable<System.DateTime> Fecha_venta { get; set; }

        [Display(Name = "Total de venta")]
        public Nullable<decimal> Total_venta { get; set; }

        [Display(Name = "Vendedor")]
        public Nullable<int> Id_vendedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}