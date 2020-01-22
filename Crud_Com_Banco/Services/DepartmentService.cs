using Crud_Com_Banco.Data;
using Crud_Com_Banco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Com_Banco.Services {
    public class DepartmentService {
        private readonly Crud_Com_BancoContext _context;

        public DepartmentService(Crud_Com_BancoContext context) {
            _context = context;
        }

        public List<Department> FindAll() {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
