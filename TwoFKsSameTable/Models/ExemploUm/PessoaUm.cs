using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwoFKsSameTable.Models.ExemploUm {
   public class PessoaUm {

      [Key]
      public int Id { get; set; }

      public string Nome { get; set; }

      public string Funcao { get; set; }



      // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      // Definição de Chaves Forasteiras, utilizando [Anotações]
      // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      //https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/data-annotations?redirectedfrom=MSDN#relationship-attributes-inverseproperty-and-foreignkey

      /* quando se criam duas FKs sobre a mesma tabela
       * a EF tem mais dificuldade em criar os relacionamentos.
       * 
       * Do lado UM, especificam-se as FKs como usual.
       * MAS, do lado MUITOS é necessário referir a que FK a lista se relaciona
       * através da anotação  [InverseProperty("NomeDoObjetoQueE_FK")]
       * 
       * ATENÇÃO: Quando se usa este método é OBRIGATÓRIO que no código da migração
       *          se altere o atributo 'cascade' para 'restrict' no relacionamento.
       *          
       */

      [InverseProperty("Medico")] // obrigatório referenciar a Classe, não a variável INT
      public ICollection<ReceitaUm> ListaReceitasCriadas { get; set; }

      [InverseProperty("Utente")]
      public ICollection<ReceitaUm> ListaReceitasAtribuidas { get; set; }
   }
}
