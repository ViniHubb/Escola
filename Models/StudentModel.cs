using Escola.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Escola.Models
{
    public class StudentModel
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; init; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Classe { get; private set; }
        public float GPA {  get; private set; }
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int Age { get; private set; }

        public StudentModel(string Name, string Surname, DateOnly DateOfBirth, string Classe, float GPA, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.Classe = Classe;
            this.GPA = GPA;
            this.Age = DateTime.Today.Year - DateOfBirth.Year;
        }

        public void Modify(StudentDTO newSudent)
        {
            this.Classe = newSudent.Classe;
            this.GPA = newSudent.GPA;
        }
    }
}
