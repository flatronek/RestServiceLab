using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInterfaces
{
    public interface IAuthorsRepository
    {
        int Add(Author author);

        bool Delete(int id);

        Author Get(int id);

        List<Author> GetAll();

        Author Update(Author author);
    }
}
