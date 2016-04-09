using Database;
using DbInterfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RESTService.Controllers
{
    public class BooksController : ApiController
    {
        private IBooksRepository _booksRepository;

        public BooksController()
        {
            _booksRepository = new BooksRepository();
        }


        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return _booksRepository.GetAll();
        }

        // GET: api/books?search=book1
        public IEnumerable<Book> Get([FromUri] string search)
        {
            return _booksRepository.GetAll().Where(x => x.BookTitle.ToLower().Contains(search.ToLower()));
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            return _booksRepository.Get(id);
        }

        // POST: api/Books
        public HttpResponseMessage Post([FromBody] Book value)
        {
            int id = _booksRepository.Add(value);

            return Request.CreateResponse<int>(HttpStatusCode.Created, id);
        }

        // PUT: api/Books/5
        public HttpResponseMessage Put(int id, [FromBody]Book value)
        {
            Book updatedBook = _booksRepository.Update(value);

            return Request.CreateResponse<Book>(HttpStatusCode.Accepted, updatedBook);
        }

        // DELETE: api/Books/5
        public HttpResponseMessage Delete(int id)
        {
            bool deleted = _booksRepository.Delete(id);

            return Request.CreateResponse<bool>(HttpStatusCode.OK, deleted);
        }
    }
}
