using System;
using System.Collections.Generic;
using PhotoBook.Models;

namespace PhotoBook.Data
{
    public class PhotoRepository : GenericRepository<Photo>
    {
        public PhotoRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
