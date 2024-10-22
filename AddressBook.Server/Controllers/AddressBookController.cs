using AddressBook.data.Models;
using AddressBook.data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookRepository _addressBookRepository;
        public AddressBookController(IAddressBookRepository addressBookRepository)
        {
            _addressBookRepository = addressBookRepository;
        }

        [HttpGet]
        [Route("GetAddresses")]
        public async Task<IActionResult> GetAddresses()
        {
            try
            {
                var addresses = await _addressBookRepository.GetAddressBookList();
                
                return Ok(addresses);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAddressBookDetails")]
        public async Task<IActionResult> GetAddressBookDetails(int id)
        {
            try
            {
                var address = await _addressBookRepository.GetAddresBookCompleteById(id);

                return Ok(address);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
