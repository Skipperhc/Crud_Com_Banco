using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Com_Banco.Models {
    public class Seller {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")] //diz que é obrigatório ter isso preenchido, o {0} passa o nome da variavel
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Name size should be between {2} and {1}")]
        //mostra o máximo e o mínimo requerido da string, {0} passa o nome da variavel, {2} o minimo {1} máximo
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name="Birth Date")] //customiza o que aparece na coluna
        [DataType(DataType.Date)] //muda de texto para um link de email mesmo
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//para definir qual formato vai aparecer, no caso dia/mes/ano
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Salario")]//mudo o nome que aparece na coluna
        [DisplayFormat(DataFormatString ="{0:F2}")]//escolher quantos zeros depois da vircula mostrar
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} To {2}")]//estou falando o min e o max que o salario deve ter
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }


        //public Boolean active { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
