using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwoFKsSameTable.Models.ExemploUm {
   public class ReceitaUm {


      [Key]
      public int Id { get; set; }

      public DateTime Data { get; set; }

      public string Prescricao { get; set; }


      // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      // Definição de Chaves Forasteiras, utilizando [Anotações]
      // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

      /// <summary>
      /// especificação da FK que refere o Médico que preescreve a Receita
      /// </summary>
      [ForeignKey(nameof(Medico))]
      public int MedicoFK { get; set; }
      public PessoaUm Medico { get; set; }


      /// <summary>
      /// especificação da FK que refere o Utente que recebe a Receita
      /// </summary>
      [ForeignKey(nameof(Utente))]
      public int UtenteFK { get; set; }
      public PessoaUm Utente { get; set; }



   }
}
