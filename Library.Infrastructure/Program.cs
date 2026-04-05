using Library.Domain.Entities;
using Library.Domain.ValueObjects;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Infrastructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using (var context = new AppDbContext())
            // {

                /*
                Address address = new Address("Damascus", "Al-Mazzeh", "Street 111");
                Email email = new Email("Maya@gmail.com");

                
                Person person = new Person("Maya", "Alali", 'F', address, email);
                person.AuditTimestamp!.CreateAt = DateTime.Now;
                person.AuditTimestamp!.UpdateAt = null;

                context.People.Add(person);
                context.SaveChanges();
                Console.WriteLine("Done1");


                PhoneNumber phoneNumber = new PhoneNumber("+963 988 000 222", person.Id);
                context.PhoneNumbers.Add(phoneNumber); 
                context.SaveChanges(); 
                Console.WriteLine("Done2");

                User user = new User(person.Id,Guid.NewGuid().ToString().Substring(0,19).Replace("-","$"),BCrypt.Net.BCrypt.HashPassword("Password2"));
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine("Done3");
                */




                /*
                var User = context.Users.Include(u=>u.Person).Single(u => u.Id == 2);
                User.Person.UpdateAddress( new Address("Damascus", "Mazzeh", "Street 000"));
                User.Person.UpdateEmail( new Email("MayaT@gmail.com"));
                User.Person.FirstName = "May";
                User.Person.LastName = "Ali";
                User.IsDeleted = true;
                User.Person.AuditTimestamp!.UpdateAt = DateTime.Now;
                context.SaveChanges();
                Console.WriteLine("Done...");
                */


                /*
                List<Book> books = new List<Book>
                {
                    new Book("The Great Gatsby", "9780743263565", new DateTime(1925, 4, 10), "Fiction", "Classic novel set in the Jazz Age."),
                    new Book("1984", "9780452524935", new DateTime(1949, 6, 8), "Dystopian", "A novel about totalitarianism and surveillance."),
                    new Book("To Kill a Mockingbird", "9680061120084", new DateTime(1960, 7, 11), "Fiction", "Deals with racial injustice in the American South."),
                    new Book("Pride and Prejudice", "9780141439518", new DateTime(1813, 1, 28), "Romance", "Classic romantic novel by Jane Austen."),
                    new Book("The Catcher in the Rye", "9780316769488", new DateTime(1951, 7, 16), "Fiction", "Story of teenage angst and alienation."),
                    new Book("Brave New World", "9780060850524", new DateTime(1932, 8, 18), "Dystopian", "A futuristic society controlled by technology and conditioning."),
                    new Book("Moby Dick", "9781503280786", new DateTime(1851, 11, 14), "Adventure", "Epic tale of Captain Ahab's obsession with a white whale."),
                    new Book("War and Peace", "9781400079988", new DateTime(1869, 1, 1), "Historical", "A story of Russian society during the Napoleonic era."),
                    new Book("The Hobbit", "9780547928227", new DateTime(1937, 9, 21), "Fantasy", "Bilbo Baggins' adventure to reclaim a treasure from a dragon."),
                    new Book("The Lord of the Rings", "9780544003415", new DateTime(1954, 7, 29), "Fantasy", "Epic journey to destroy the One Ring."),
                    new Book("Jane Eyre", "9780141441146", new DateTime(1847, 10, 16), "Romance", "A novel about love, morality, and social criticism."),
                    new Book("Animal Farm", "9780451526342", new DateTime(1945, 8, 17), "Satire", "Allegorical novella about power and corruption."),
                    new Book("Crime and Punishment", "9780143058144", new DateTime(1866, 1, 1), "Psychological", "Explores morality, guilt, and redemption in St. Petersburg.")
                };

                context.Books.AddRange(books);
                context.SaveChanges();
                Console.WriteLine("Done...");
                */

                /*

                List<BookCopy> bookCopies = new List<BookCopy>
                {
                    // BookId = 1
                    new BookCopy(1, true), new BookCopy(1, true), new BookCopy(1, false),
                    new BookCopy(1, true), new BookCopy(1, false), new BookCopy(1, true),

                    // BookId = 2
                    new BookCopy(2, true), new BookCopy(2, false), new BookCopy(2, true),
                    new BookCopy(2, true), new BookCopy(2, false), new BookCopy(2, true),

                    // BookId = 3
                    new BookCopy(3, true), new BookCopy(3, true), new BookCopy(3, true),
                    new BookCopy(3, false), new BookCopy(3, true),

                    //// BookId = 4
                    //new BookCopy(4, true), new BookCopy(4, false), new BookCopy(4, true),
                    //new BookCopy(4, true), new BookCopy(4, true), new BookCopy(4, false),

                    //// BookId = 5
                    //new BookCopy(5, true), new BookCopy(5, true), new BookCopy(5, false),
                    //new BookCopy(5, true), new BookCopy(5, false),

                    //// BookId = 6
                    //new BookCopy(6, true), new BookCopy(6, false), new BookCopy(6, true),
                    //new BookCopy(6, true), new BookCopy(6, true), new BookCopy(6, false),

                    // BookId = 7
                    new BookCopy(7, true), new BookCopy(7, true), new BookCopy(7, false),
                    new BookCopy(7, true), new BookCopy(7, true),

                    // BookId = 8
                    new BookCopy(8, false), new BookCopy(8, true), new BookCopy(8, true),
                    new BookCopy(8, false), new BookCopy(8, true), new BookCopy(8, true),

                    // BookId = 9
                    new BookCopy(9, true), new BookCopy(9, true), new BookCopy(9, false),
                    new BookCopy(9, true), new BookCopy(9, false),

                    // BookId = 10
                    new BookCopy(10, true), new BookCopy(10, true), new BookCopy(10, true),
                    new BookCopy(10, false), new BookCopy(10, true), new BookCopy(10, false),

                    // BookId = 11
                    new BookCopy(11, true), new BookCopy(11, false), new BookCopy(11, true),
                    new BookCopy(11, true), new BookCopy(11, true),

                    // BookId = 12
                    new BookCopy(12, true), new BookCopy(12, true), new BookCopy(12, false),
                    new BookCopy(12, true), new BookCopy(12, true), new BookCopy(12, false),

                    // BookId = 13
                    new BookCopy(13, true), new BookCopy(13, false), new BookCopy(13, true),
                    new BookCopy(13, true), new BookCopy(13, false),

                    // BookId = 14
                    new BookCopy(14, true), new BookCopy(14, true), new BookCopy(14, true),
                    new BookCopy(14, false), new BookCopy(14, true), new BookCopy(14, false),

                    // BookId = 15
                    new BookCopy(15, true), new BookCopy(15, true), new BookCopy(15, false),
                    new BookCopy(15, true), new BookCopy(15, true),

                    // BookId = 16
                    new BookCopy(16, true), new BookCopy(16, false), new BookCopy(16, true),
                    new BookCopy(16, true), new BookCopy(16, true), new BookCopy(16, false),

                    // BookId = 17
                    new BookCopy(17, true), new BookCopy(17, true), new BookCopy(17, false),
                    new BookCopy(17, true), new BookCopy(17, false),

                    // BookId = 18
                    new BookCopy(18, true), new BookCopy(18, true), new BookCopy(18, true),
                    new BookCopy(18, false), new BookCopy(18, true), new BookCopy(18, false),

                    // BookId = 19
                    new BookCopy(19, true), new BookCopy(19, false), new BookCopy(19, true),
                    new BookCopy(19, true), new BookCopy(19, true)
                };

                context.BookCopies.AddRange(bookCopies);
                context.SaveChanges();
                Console.WriteLine("Done...");
                */

                /*
                List<Reservation> reservations = new List<Reservation>
                {
                    new Reservation(2, 19),
                    new Reservation(2, 25),
                    new Reservation(2, 31),

                };
                context.Reservations.AddRange(reservations);
                context.SaveChanges();
                Console.WriteLine("Done...");
                */

                /*
                List<PaymentMethod> paymentMethods = new List<PaymentMethod>
                {
                   new PaymentMethod ("Cash",  "Pay with physical cash at the counter." ),
                   new PaymentMethod ("Credit Card",  "Pay using a credit card (Visa, MasterCard, etc.)." ),
                   new PaymentMethod ("Debit Card",  "Pay directly from your bank account using a debit card." ),
                   new PaymentMethod ("PayPal",  "Secure online payments via PayPal." ),
                   new PaymentMethod ("Bank Transfer",  "Transfer funds directly from your bank account." ),
                   new PaymentMethod ("Mobile Payment",  "Pay using mobile wallets like Apple Pay or Google Pay." ),
                   new PaymentMethod ("Gift Card",  "Use a prepaid gift card or voucher." ),
                   new PaymentMethod ("Cryptocurrency",  "Pay using digital currencies like Bitcoin or Ethereum." )
                };

                context.PaymentMethods.AddRange(paymentMethods);
                context.SaveChanges();
                Console.WriteLine("Done...");
                */
                /*

               List<BorrowingRecord> borrowingRecords = new List<BorrowingRecord>
               {
                   new BorrowingRecord(2, 41, DateTime.Now.AddDays(7)),
                   new BorrowingRecord(2, 47, DateTime.Now.AddDays(10)),

               };
               context.BorrowingRecords.AddRange(borrowingRecords);
               context.SaveChanges();
               Console.WriteLine("Done...");
               */
                /*
                Setting setting = new Setting(10,2);
                context.Settings.Add(setting);
                context.SaveChanges();
                Console.WriteLine("Done...");
               */
           // }
        }
    }
}
