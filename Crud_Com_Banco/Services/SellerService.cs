using Crud_Com_Banco.Data;
using Crud_Com_Banco.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Crud_Com_Banco.Services.Exceptions;

namespace Crud_Com_Banco.Services {
    public class SellerService {
        private readonly Crud_Com_BancoContext _context;

        public SellerService(Crud_Com_BancoContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj) {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj) {
            if (!_context.Seller.Any(x => x.Id == obj.Id)) {
                throw new NotFoundException("id Not found");
            }
            try {
                _context.Update(obj);
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException e) {
                throw new NotFoundException(e.Message);
            }
        }

    }
}
