namespace Apmt_WPF.Features.Users;

public record struct UserRegisterDto(
    string username, 
    string email,
    string password,
    string passwordConfirmation);
