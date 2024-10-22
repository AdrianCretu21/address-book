using AddressBook.data.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.data.Repository
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly AddressBookContext _addressBookRepository;
        public AddressBookRepository(AddressBookContext addressBookContext)
        {
            _addressBookRepository = addressBookContext;
        }

        public async Task<AddressBookModel?> GetAddresBookCompleteById(int id)
         => await _addressBookRepository.AddressBooks.Where(el => el.Id == id).FirstOrDefaultAsync();

        public async Task<List<AddressBookListModel>> GetAddressBookList()
        => await _addressBookRepository.AddressBooks.Select(el => new AddressBookListModel
        {
            FirstName = el.FirstName,
            LastName = el.LastName,
            Id = el.Id,
            ImageName = el.ImageName,
        }).ToListAsync();

    }
}
