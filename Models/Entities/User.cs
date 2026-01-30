using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_notificacao_escolar_back.Models.Entities
{
  public class User
  {
    [Key]
    public int Id{get;set;}
    public string Username{get;set;}
    public string Password{get;set;}
    public string Email{get;set;}
    public string CPF{get;set;}
    public int RoleId{get;set;}
    [ForeignKey("RoleId")]
    public Role Role{get;set;} //referencia da classe role
  }
}