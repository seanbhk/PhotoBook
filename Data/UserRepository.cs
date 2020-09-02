using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhotoBook.Models;

namespace PhotoBook.Data
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
