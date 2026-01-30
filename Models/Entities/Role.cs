using System.ComponentModel.DataAnnotations;

namespace sistema_notificacao_escolar_back.Models.Entities
{
  public class Role
  {
    [Key]
    public int Id{get;set;}
    public string Name{get;set;}
  }
}