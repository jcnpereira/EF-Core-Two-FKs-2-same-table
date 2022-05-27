using System.ComponentModel.DataAnnotations;

namespace TwoFKsSameTable.Models.ExemploDois {
   public class PessoaDois {

      [Key]
      public int Id { get; set; }

      public string Nome { get; set; }

      public string Funcao { get; set; }

      
      public ICollection<ReceitaDois> ListaReceitasCriadas { get; set; }


      public ICollection<ReceitaDois> ListaReceitasAtribuidas { get; set; }
   }
}
