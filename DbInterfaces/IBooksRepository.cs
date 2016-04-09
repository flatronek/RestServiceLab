using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInterfaces
{
    public interface IBooksRepository
    {
        int Add(Book book);

        bool Delete(int id);

        Book Get(int id);

        List<Book> GetAll();

        Book Update(Book book);
    }
}
