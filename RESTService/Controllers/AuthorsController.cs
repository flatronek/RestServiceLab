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
    public class AuthorsController : ApiController
    {
        private IAuthorsRepository _authorsRepository;

        public AuthorsController()
        {
            _authorsRepository = new AuthorsRepository();
        }

        // GET: api/authors
        public IEnumerable<Author> Get()
        {
            return _authorsRepository.GetAll();
        }

        // GET: api/authors?search=book1
        public IEnumerable<Author> Get([FromUri] string search)
        {
            return _authorsRepository.GetAll().Where(x =>
                        x.Surname.ToLower().Contains(search.ToLower()) || x.Name.ToLower().Contains(search.ToLower()));
        }

        // GET: api/authors/5
        public Author Get(int id)
        {
            return _authorsRepository.Get(id);
        }

        // POST: api/authors
        public HttpResponseMessage Post([FromBody] Author value)
        {
            int id = _authorsRepository.Add(value);

            return Request.CreateResponse<int>(HttpStatusCode.Created, id);
        }

        // PUT: api/authors/5
        public HttpResponseMessage Put(int id, [FromBody] Author value)
        {
            Author updatedAuthor = _authorsRepository.Update(value);

            return Request.CreateResponse<Author>(HttpStatusCode.Accepted, updatedAuthor);
        }

        // DELETE: api/authors/5
        public HttpResponseMessage Delete(int id)
        {
            bool deleted = _authorsRepository.Delete(id);

            return Request.CreateResponse<bool>(HttpStatusCode.OK, deleted);
        }
    }
}
