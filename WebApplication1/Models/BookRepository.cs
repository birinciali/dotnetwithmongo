using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BookRepository : Repository<Books>, IBookRepository // base class, interfaceden önce yazılmalıdır. 
                                                                    // her classın yalnız bir base classı,
                                                                    // birden fazla interfacesi olabilir.
    {
        public BookRepository(IMongoDbContext context) : base(context)
        {

        }
    }
}
