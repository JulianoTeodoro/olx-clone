using backend.Data;
using backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class UserService 
    {
        protected AppDbContext _context;

        public UserService(AppDbContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<States> getStates()
        {
            return _context.states.ToList();
        }
    }
}
