using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() {

        var users = await context.Users.ToListAsync();

        return users;
        
    }

    [HttpGet("{id:int}")] // /api/users/{id}
    public async Task<ActionResult<AppUser>> GetUser(int id) {

        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return user;
    }

    [HttpGet("username/{username}")] // /api/users/username/{username}
    public async Task<ActionResult<AppUser>> GetUserByUserName(string username) {

        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null) return NotFound();

        return user;
    }
}
