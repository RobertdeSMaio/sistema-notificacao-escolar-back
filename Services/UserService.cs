using SistemaNotificacaoEscolarBack.Models.Entities;
using SistemaNotificacaoEscolarBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;
using SistemaNotificacaoEscolarBack.Models.DTOs;


public class UserService : IUserService
{
    private readonly MyDbContext _context;

    public async Task<UserResponse> RegisterAsync(CreateUserRequest request)
    {
        var user = new User {
            Name = request.Name,
            Email = request.Email,
            Cpf = request.Cpf
        };

        user.SetPassword(request.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserResponse(user.Id, user.Name, user.Email, user.Cpf.ToString(), user.CreatedAt);
    }

    public async Task<UserResponse> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;

        return new UserResponse(user.Id, user.Name, user.Email, user.Cpf.ToString(), user.CreatedAt);
    }

    public async Task<UserResponse> LoginAsync(CreateUserRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
            return null;

        if (!user.VerifyPassword(request.Password))
            return null;

        return new UserResponse(user.Id, user.Name, user.Email, user.Cpf.ToString(), user.CreatedAt);
    }
}