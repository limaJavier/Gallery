using Gallery.Application.Handlers.Authentication.Common;
using MediatR;

namespace Gallery.Application.Handlers.Authentication.Commands.Register;

public record RegisterCommand(
    string Name,
    string LastName,
    string Email,
    string Password
) : IRequest<AuthenticationResponse>;

// string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

// Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);
          

//            if (re.IsMatch(inputEmail))
//             return (true);
//         else
//             return (false);