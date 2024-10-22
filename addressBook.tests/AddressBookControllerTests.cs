using AddressBook.data.Models;
using AddressBook.data.Repository;
using AddressBook.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace addressBook.tests
{
    [TestClass]
    public class AddressBookControllerTests
    {
        private Mock<IAddressBookRepository> _addressBookRepositoryMoq;
        private List<AddressBookListModel> allDataList =
        [
            new AddressBookListModel(){
                Id = 1,
                FirstName = "Adrian",
                LastName = "Cretu",
                ImageName = "1.jpg"
            },
            new AddressBookListModel(){
                Id = 2,
                FirstName = "Maria",
                LastName = "Ionescu",
                ImageName = "2.jpg"
            },
            new AddressBookListModel(){
                Id = 3,
                FirstName = "Ion",
                LastName = "Popescu",
                ImageName = "3.jpg"
            },
        ];
        private List<AddressBookModel?> allDataCompleted =
        [
             new AddressBookModel(){
                        Id = 1,
                        FirstName = "Adrian",
                        LastName = "Cretu",
                        Address = "Ploiesti",
                        LocationLat = 44.940087766853466,
                        LocationLon = 26.024721381603694,
                        PhoneNumber = "0770390979",
                        ImageName = "1.jpg"
                    },
                    new AddressBookModel(){
                        Id = 2,
                        FirstName = "Maria",
                        LastName = "Ionescu",
                        Address = "București",
                        LocationLat = 44.4267674,
                        LocationLon = 26.1025384,
                        PhoneNumber = "0741234567",
                        ImageName = "2.jpg"
                    },
                    new AddressBookModel(){
                        Id = 3,
                        FirstName = "Ion",
                        LastName = "Popescu",
                        Address = "Cluj-Napoca",
                        LocationLat = 46.7712101,
                        LocationLon = 23.6236353,
                        PhoneNumber = "0732233444",
                        ImageName = "3.jpg"
                    },
        ];
        public AddressBookControllerTests()
        {
            _addressBookRepositoryMoq = new Mock<IAddressBookRepository>();
        }
        [TestMethod]
        [TestCategory("List")]
        public async Task Should_Get_All_Addresses()
        {
            _addressBookRepositoryMoq.Setup(s => s.GetAddressBookList()).Returns(Task.FromResult(allDataList));
            AddressBookController addressBookController = new AddressBookController(_addressBookRepositoryMoq.Object);

            var res = await addressBookController.GetAddresses();
            
            Assert.IsInstanceOfType(res, typeof(OkObjectResult));
            var okResult = res as OkObjectResult;
            var dataFromController = okResult!.Value as List<AddressBookListModel>;
            Assert.AreEqual(3, dataFromController!.Count);
        }
        [TestMethod]
        [TestCategory("List")]
        public async Task Should_Return_500_If_Data_Cannot_Be_Extracted()
        {
            string error = "Data Error";
            _addressBookRepositoryMoq.Setup(s => s.GetAddressBookList()).Throws(new Exception(error));
            AddressBookController addressBookController = new AddressBookController(_addressBookRepositoryMoq.Object);

            var res = await addressBookController.GetAddresses();

            var failResult = res as ObjectResult;
            Assert.AreEqual(500, failResult!.StatusCode);
            Assert.AreEqual(error, failResult!.Value);
        }

        [TestMethod]
        [TestCategory("Details")]
        public async Task Should_Retrun_The_Desired_AddressBook_Details_By_Id()
        {
            _addressBookRepositoryMoq.Setup(s => s.GetAddresBookCompleteById(2)).Returns(Task.FromResult(allDataCompleted[1]));
            AddressBookController addressBookController = new AddressBookController(_addressBookRepositoryMoq.Object);

            var res = await addressBookController.GetAddressBookDetails(2);
            var okResult = res as OkObjectResult;
            var dataFromController = okResult!.Value as AddressBookModel;
            
            Assert.IsInstanceOfType(res, typeof(OkObjectResult));
            Assert.AreEqual(2,dataFromController!.Id);
        }

        [TestMethod]
        [TestCategory("Details")]
        public async Task Should_Retrun_Null_If_The_Id_Does_Not_Exist_In_Database()
        {
            _addressBookRepositoryMoq.Setup(s => s.GetAddresBookCompleteById(23220)).CallBase();
            AddressBookController addressBookController = new AddressBookController(_addressBookRepositoryMoq.Object);

            var res = await addressBookController.GetAddressBookDetails(20);
            var okResult = res as OkObjectResult;
            var dataFromController = okResult!.Value as AddressBookModel;

            Assert.AreEqual(200, okResult!.StatusCode);
            Assert.IsNull(dataFromController);
        }
        [TestMethod]
        [TestCategory("Details")]
        public async Task Should_Return_500_If_Detail_Data_Cannot_Be_Extracted()
        {
            string error = "Data Error";
            _addressBookRepositoryMoq.Setup(s => s.GetAddresBookCompleteById(It.IsAny<int>())).Throws(new Exception(error));
            AddressBookController addressBookController = new AddressBookController(_addressBookRepositoryMoq.Object);

            var res = await addressBookController.GetAddressBookDetails(1);

            var failResult = res as ObjectResult;
            Assert.AreEqual(500, failResult!.StatusCode);
            Assert.AreEqual(error, failResult!.Value);
        }
    }
}