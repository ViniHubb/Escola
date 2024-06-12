namespace Escola.Models
{
    public class StudentModel
    {
        public int Id { get; init; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Class { get; private set; }
        public float GPA {  get; private set; }

        public StudentModel(string Name, string Surname, DateTime DateOfBirth, string Class, float GPA)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.Class = Class;
            this.GPA = GPA;
        }
    }
}
