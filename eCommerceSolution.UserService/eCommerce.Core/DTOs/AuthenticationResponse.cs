using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.eCommerce.Core.DTOs
{
    public record AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success
    )
    {
        // parameterless constructure for AutoMapper execution
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        {

        }
    }
}
