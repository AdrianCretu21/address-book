using AddressBook.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.data.Repository
{
    public interface IAddressBookRepository
    {
        public Task<AddressBookModel?> GetAddresBookCompleteById(int id);
        public Task<List<AddressBookListModel>> GetAddressBookList();
    }
}
