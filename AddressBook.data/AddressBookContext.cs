using AddressBook.data.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.data
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext() {
            EnsureAllSet();
        }
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options) {
            EnsureAllSet();
        }
        public DbSet<AddressBookModel> AddressBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressBookModel>().HasData(
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
                    new AddressBookModel(){
                        Id = 4,
                        FirstName = "Elena",
                        LastName = "Vasilescu",
                        Address = "Iași",
                        LocationLat = 47.156944,
                        LocationLon = 27.590278,
                        PhoneNumber = "0722233444",
                        ImageName = "4.jpg"
                    },
                    new AddressBookModel(){
                        Id = 5,
                        FirstName = "Mihai",
                        LastName = "Georgescu",
                        Address = "Timișoara",
                        LocationLat = 45.7488716,
                        LocationLon = 21.2086793,
                        PhoneNumber = "0711234567",
                        ImageName = "5.jpg"
                    },
                    new AddressBookModel(){
                        Id = 6,
                        FirstName = "Ana",
                        LastName = "Radu",
                        Address = "Brașov",
                        LocationLat = 45.6579746,
                        LocationLon = 25.6011982,
                        PhoneNumber = "0765234567",
                        ImageName = "6.jpg"
                    },
                    new AddressBookModel(){
                        Id = 7,
                        FirstName = "Cristian",
                        LastName = "Marin",
                        Address = "Constanța",
                        LocationLat = 44.1598,
                        LocationLon = 28.6348,
                        PhoneNumber = "0701234567",
                        ImageName = "7.jpg"
                    },
                    new AddressBookModel(){
                        Id = 8,
                        FirstName = "Diana",
                        LastName = "Tudor",
                        Address = "Craiova",
                        LocationLat = 44.3302,
                        LocationLon = 23.7949,
                        PhoneNumber = "0751234567",
                        ImageName = "8.jpg"
                    },
                    new AddressBookModel(){
                        Id = 9,
                        FirstName = "Victor",
                        LastName = "Grigore",
                        Address = "Galați",
                        LocationLat = 45.4353,
                        LocationLon = 28.0077,
                        PhoneNumber = "0781234567",
                        ImageName = "9.jpg"
                    },
                    new AddressBookModel(){
                        Id = 10,
                        FirstName = "Monica",
                        LastName = "Dumitrescu",
                        Address = "Oradea",
                        LocationLat = 47.0465,
                        LocationLon = 21.9189,
                        PhoneNumber = "0791234567",
                        ImageName = "10.jpg"
                    }

                ]
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../AddressBook.data/AddressBooks.db");
        }
        private void EnsureAllSet()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            SQLitePCL.Batteries.Init();
        }
    }
}