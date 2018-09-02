namespace VendaDireta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Produto = new HashSet<Produto>();
        }

        [DisplayName("Cód.")]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Usuário")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Senha { get; set; }

        public decimal Receita { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
