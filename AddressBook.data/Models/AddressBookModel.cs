using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.data.Models
{
    public class AddressBookModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string ImageName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double LocationLat { get; set; }
        public double LocationLon { get; set; }
    }

    public class AddressBookListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string ImageName { get; set; }
        public string LastName { get; set; }
    }
}
