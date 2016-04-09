using DbInterfaces;
using LiteDB;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class BooksRepository : IBooksRepository
    {
        public int Add(Book book)
        {
            using (var db = new LiteDatabase(DatabaseConnections.BooksConnection))
            {
                var repository = db.GetCollection<Book>("books");

                if (repository.FindById(book.Id) != null)
                    repository.Update(book);
                else
                    repository.Insert(book);

                return book.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(DatabaseConnections.BooksConnection))
            {
                var repository = db.GetCollection<Book>("books");

                return repository.Delete(id);
            }
        }

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(DatabaseConnections.BooksConnection))
            {
                var repository = db.GetCollection<Book>("books");

                return repository.FindById(id);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(DatabaseConnections.BooksConnection))
            {
                return db.GetCollection<Book>("books").FindAll().ToList();
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(DatabaseConnections.BooksConnection))
            {
                var repository = db.GetCollection<Book>("books");

                if (repository.Update(book))
                    return book;
                else
                    return null;
            }
        }
    }
}
