using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Com_Banco.Models {
    public class Seller {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name="Birth Date")] //customiza o que aparece na coluna
        [DataType(DataType.Date)] //muda de texto para um link de email mesmo
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//para definir qual formato vai aparecer, no caso dia/mes/ano
        public DateTime BirthDate { get; set; }
        [Display(Name = "Salario")]//mudo o nome que aparece na coluna
        [DisplayFormat(DataFormatString ="{0:F2}")]//escolher quantos zeros depois da vircula mostrar
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
