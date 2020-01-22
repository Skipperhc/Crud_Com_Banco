using Crud_Com_Banco.Data;
using Crud_Com_Banco.Models;
using System.Collections.Generic;
using System.Linq;

namespace Crud_Com_Banco.Services {
    public class SellerService {
        private readonly Crud_Com_BancoContext _context;

        public SellerService(Crud_Com_BancoContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
    }
}
