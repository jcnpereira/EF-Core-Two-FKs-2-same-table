using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwoFKsSameTable.Models.ExemploDois {
   public class ReceitaDois {


      [Key]
      public int Id { get; set; }

      public DateTime Data { get; set; }

      public string Prescricao { get; set; }




      // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      // atributos para especificar as FKs
      // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      /*
       * As FKs serão definidas através do FluentAPI
       * https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
       */

      public int MedicoFK { get; set; }
      public PessoaDois Medico { get; set; }

      
      public int UtenteFK { get; set; }
      public PessoaDois Utente { get; set; }



   }
}
