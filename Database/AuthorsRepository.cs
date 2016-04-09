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
    public class AuthorsRepository: IAuthorsRepository
    {
        private readonly string _reviewsConnection = DatabaseConnections.AuthorsConnection;
        private readonly string _collectionName = "authors";

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(_reviewsConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                if (repository.FindById(author.Id) != null)
                    repository.Update(author);
                else
                    repository.Insert(author);

                return author.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(_reviewsConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                return repository.Delete(id);
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(_reviewsConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                return repository.FindById(id);
            }
        }

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(_reviewsConnection))
            {
                return db.GetCollection<Author>(_collectionName).FindAll().ToList();
            }
        }

        public Author Update(Author review)
        {
            using (var db = new LiteDatabase(_reviewsConnection))
            {
                var repository = db.GetCollection<Author>(_collectionName);

                if (repository.Update(review))
                    return review;
                else
                    return null;
            }
        }
    }
}
