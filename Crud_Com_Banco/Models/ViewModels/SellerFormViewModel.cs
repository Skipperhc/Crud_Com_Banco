using System.Collections.Generic;

namespace Crud_Com_Banco.Models.ViewModels {
    public class SellerFormViewModel {
        public Seller Seller {get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
