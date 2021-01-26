using Consensus.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Consensus.WEB.Models
{
    public class ProduccionModel : AbstractValidatableObject
    {
        public int IdProduccion { get; set; }
        
        [Required(ErrorMessage="* Debe ingresar una fecha menor igual a la fecha actual")]
        public DateTime Fecha { get; set; }
        
        [Required(ErrorMessage = "* Debe seleccionar una figura")]
        public int IdFigura { get; set; }
        public string Figura { get; set; }
        
        [Required(ErrorMessage = "* Debe ingresar una combinación de piezas")]
        [Range(1, 9999999, ErrorMessage = "La combinación de piezas debe estar entre 1 y 9999999")]
        public int Combinacion { get; set; }

        [Required(ErrorMessage = "* Debe ingresar la cantidad de sets de piezas")]
        [Range(1, 9999999, ErrorMessage = "La cantidad de sets de piezas debe estar entre 1 y 9999999")]

        public int CantidadSets { get; set; }
        
        public int CantidadTotal { get; set; }
        
        public decimal PrecioSet { get; set; }
        
        public decimal PrecioTotal { get; set; }
        
        //Para cargar el combo de figuras
        public IEnumerable<SelectListItem> Figuras { get; set; }

        public override async Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext, CancellationToken cancellation)
        {
            var errors = new List<ValidationResult>();

            if (Fecha > DateTime.Now.Date)
            {
                errors.Add(new ValidationResult($"La fecha no puede ser mayor a {DateTime.Now.Date.ToShortDateString()}.", new[] { nameof(Fecha) }));
            }
            return errors;
        }
    }
}
