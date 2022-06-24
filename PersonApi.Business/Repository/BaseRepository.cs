using PersonApi.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonApi.Business.Repository
{
    public class BaseRepository
        
    {
        protected readonly PersonApiContext _context;
        public BaseRepository()
        {
                    
        }

        public BaseRepository(PersonApiContext context )
        {
            _context=context;
        }
    }
}
