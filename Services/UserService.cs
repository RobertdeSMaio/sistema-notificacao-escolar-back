using SistemaNotificacaoEscolarBack.Models.Entities;
using SistemaNotificacaoEscolarBack.Data.Context;
using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;
using SistemaNotificacaoEscolarBack.Models.DTOs;
using SistemaNotificacaoEscolar.Controllers;


public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserResponse> RegisterAsync(CreateUserRequest request)
    {
        // 1. Instancia a entidade
        var user = new User {
            Name = request.Name,
            Email = request.Email,
            Cpf = request.Cpf ?? string.Empty
        };

        // 2. Usa o método que você já criou no modelo!
        user.SetPassword(request.Password);

        // 3. Salva
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserResponse(user.Id, user.Name, user.Email, user.Cpf.ToString(), user.CreatedAt);
    }

    public async Task<UserResponse?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return null;

        return new UserResponse(user.Id, user.Name, user.Email, user.Cpf.ToString(), user.CreatedAt);
    }

    public async Task<UserResponse?> LoginAsync(CreateUserRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null)
            return null;

        if (!user.VerifyPassword(request.Password))
            return null;

        return new UserResponse(user.Id, user.Name, user.Email, user.Cpf.ToString(), user.CreatedAt);
    }
}