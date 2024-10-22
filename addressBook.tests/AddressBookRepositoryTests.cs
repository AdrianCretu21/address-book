using AddressBook.data;
using AddressBook.data.Models;
using AddressBook.data.Repository;
using Microsoft.EntityFrameworkCore;

namespace addressBook.tests
{
    [TestClass]
    public class AddressBookRepositoryTests
    {
        [TestMethod]
        public async Task Should_Get_Address_By_Id() {
            AddressBookContext contex = new();
            AddressBookRepository addressBookRepository = new(contex);

            var result = await addressBookRepository.GetAddresBookCompleteById(3);

            Assert.AreEqual(result!.FirstName, "Ion");
        }
        [TestMethod]
        public async Task Should_Retun_Null_IF_Address_Is_Not_Found_By_Id()
        {
            AddressBookContext contex = new();
            AddressBookRepository addressBookRepository = new(contex);

            var result = await addressBookRepository.GetAddresBookCompleteById(100);

            Assert.IsNull(result);
        }
        [TestMethod]
        public async Task Should_Get_All_Address_List()
        {
            AddressBookContext contex = new();
            AddressBookRepository addressBookRepository = new(contex);

            var result = await addressBookRepository.GetAddressBookList();

            Assert.AreEqual(10, result.Count);
        }
    }
}
