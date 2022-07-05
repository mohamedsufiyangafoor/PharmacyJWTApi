using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyJWTApi.Models
{
    public interface IJwtAuthenticator
    {
        string TokenGenerator(int id, string role, string username, string password);
    }
}
