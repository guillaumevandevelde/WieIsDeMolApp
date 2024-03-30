using DeMol.App.Data;
using DeMol.Domain;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DeMol.App.Services;

public class UserService
{
    private readonly AppDbContext _context;
    

    public UserService(
        AppDbContext context
      )
    {
        _context = context;
    }
    
    public async Task CreateUserAsync(ApplicationUser? user)
    {
        var existingUser = await GetUserByMailAsync(user.Email);
        
        if( existingUser == null){
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
        }
    }
    
    
    
    public async Task<ApplicationUser?> GetUserByMailAsync(string mail)
    {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == mail);
    }
    
    public async Task<ApplicationUser?> GetUserAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}