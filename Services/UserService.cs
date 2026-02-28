using SistemaNotificacaoEscolarBack.Models.Entities;
using SistemaNotificacaoEscolarBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;
using SistemaNotificacaoEscolarBack.Models.DTOs;

namespace SistemaNotificacaoEscolarBack.Models.Services;

public class UserService : IUserService
{
    private readonly MyDbContext _context;

    public UserService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<UserResponse> RegisterAsync(CreateUserRequest request)
    {
        var emailExists = await _context.Users.AnyAsync(u => u.Email == request.Email);
    if (emailExists)
    {
        throw new Exception("Este e-mail já está cadastrado.");
    }

    var cpfExists = await _context.Users.AnyAsync(u => u.Cpf == request.Cpf);
    if (cpfExists)
    {
        throw new Exception("Este CPF já está cadastrado.");
    }
        if (request == null) return null!;

        var user = new User {
            Name = request.Name,
            Email = request.Email,
            Cpf = request.Cpf ?? string.Empty,
            Role = request.Role ?? "Student",
        };

        user.SetPassword(request.Password);


        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserResponse(
            user.Id, 
            user.Name, 
            user.Email, 
            user.Cpf, 
            user.CreatedAt, 
            user.Role
        );
}

    public async Task<UserResponse?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;

        return new UserResponse(
            user.Id, 
            user.Name, 
            user.Email, 
            user.Cpf, 
            user.CreatedAt, 
            user.Role
        );
    }

    public async Task<UserResponse?> LoginAsync(CreateUserRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        
        if (user == null || !user.VerifyPassword(request.Password))
            return null;

        return new UserResponse(
            user.Id, 
            user.Name, 
            user.Email, 
            user.Cpf, 
            user.CreatedAt, 
            user.Role
        );
    }
}