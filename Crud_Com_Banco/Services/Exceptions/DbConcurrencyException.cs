using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Com_Banco.Services.Exceptions {
    public class DbConcurrencyException : ApplicationException {

        public DbConcurrencyException(string message) : base(message) {

        }
    }
}
