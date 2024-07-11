using Microsoft.EntityFrameworkCore;
using Escola.Data;
using Escola.Models;
using Escola.DTOs;
using System.Text.RegularExpressions;


namespace Escola.Repositories
{
    public class StudentRepository
    {
        private readonly SchoolDBContext _dbContext;
        public StudentRepository(SchoolDBContext schoolDBContext)
        {
            _dbContext = schoolDBContext;
        }

        public async Task<List<Result>> GetAllStudents()
        {
            Result result;
            List<Result> resultados = new List<Result>();
            List<StudentModel> students = await _dbContext.Students.ToListAsync();
            foreach (StudentModel student in students) 
            {
                result = new Result();
                result.Success = true;
                result.Student = student;
                resultados.Add(result);
            }
            return resultados;
        }

        public async Task<Result> GetStudent(int id)
        {
            Result result = new Result();
            StudentModel? student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                result.Success = false;
                result.Error = "O estudante de ID: " + id + " não foi encontrado";
            }
            else 
            {
                result.Success = true;
                result.Student = student;
            }
            return result;
        }

        public async Task<Result> CreatStudent(StudentModel student)
        {
            Result result = new Result();
            const string nameRegex = @"^[A-Za-uÀ-Úá-ú]+$";
            const string classeRegex = @"^[A-Za-z]$";
            result.Success = true;

            if (!Regex.IsMatch(student.Name, nameRegex) || !Regex.IsMatch(student.Surname, nameRegex))
            {
                result.Success = false;
                result.Error = "Nome invalido";
                return result;
            }
            else if (!Regex.IsMatch(student.Classe, classeRegex))
            {
                result.Success = false;
                result.Error = "Classe invalida";
                return result;
            }
            else if (student.GPA < 0 || student.GPA > 10)
            {
                result.Success = false;
                result.Error = "Valor do GPA invalido";
                return result;
            }
            else if (student.Age < 0 || student.Age > 100)
            {
                result.Success = false;
                result.Error = "Data invalida";
                return result;
            }
            StudentModel? studentRepet = await _dbContext.Students.FirstOrDefaultAsync(x => x.Name == student.Name);
            if (studentRepet != null)
            {
                result.Success = false;
                result.Error = "O estudante já existe";
                return result;
            }
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            result.Student = student;
            return result;
        }

        public async Task<Result> UpdateStudent(StudentDTO studentDTO, int id)
        {
            Result result = new Result();
            const string classeRegex = @"^[A-Za-z]$";
            result.Success = true;
            if (!Regex.IsMatch(studentDTO.Classe, classeRegex))
            {
                result.Success = false;
                result.Error = "Classe invalida";
                return result;
            }
            else if (studentDTO.GPA < 0 || studentDTO.GPA > 10)
            {
                result.Success = false;
                result.Error = "Valor do GPA invalida";
                return result;
            }
            result = await GetStudent(id);
            if (result.Success) 
            {
                result.Student.Modify(studentDTO);
                _dbContext.Students.Update(result.Student);
                await _dbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Result> DeleteStudent(int id)
        {
            Result result = await GetStudent(id);
            if (result.Success)
            {
                _dbContext.Students.Remove(result.Student);
                await _dbContext.SaveChangesAsync();
            }
            return result;
        }

        public async Task<List<Result>> GetStudentFilter(float gpa, int age, string? classe)
        {
            Result result;
            List<Result> resultados = new List<Result>();
            const string classeRegex = @"^[A-Za-z]$";
            if (classe != null && !Regex.IsMatch(classe, classeRegex))
            {
                result = new Result();
                result.Success = false;
                result.Error = "Classe invalida";
                resultados.Add(result);
                return resultados;
            }
            if (gpa < 0 || gpa > 10)
            {
                result = new Result();
                result.Success = false;
                result.Error = "Valor do GPA invalido";
                resultados.Add(result);
                return resultados;
            }
            if (age < 0 || age > 100)
            {
                result = new Result();
                result.Success = false;
                result.Error = "Idade invalida";
                resultados.Add(result);
                return resultados;
            }

            List<StudentModel> students;

            if (classe == null) //Gambiarra: classe é o unico dos 3 valores que ao não ser preenchido daria ruim no where.
            {
                 students = await _dbContext.Students
                .Where(x => x.GPA >= gpa 
                && x.Age <= age)
                .ToListAsync();
            }
            else
            {
                students = await _dbContext.Students
                .Where(x => x.Classe == classe
                && x.GPA >= gpa
                && x.Age <= age)
                .ToListAsync();
            }
            foreach(StudentModel student in students)
            {
                result = new Result();
                result.Success = true;
                result.Student = student;
                resultados.Add(result);
            }
            return resultados;
        }

    }
}