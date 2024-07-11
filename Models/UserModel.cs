using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class UserModel
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; init; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; } //Viewer, Editor, Adm

        public UserModel(string UserName, string Password, string Role)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Role = Role;
        }

        public void ModifyRole(string Role)
        {
            this.Role = Role;
        }
    }
}