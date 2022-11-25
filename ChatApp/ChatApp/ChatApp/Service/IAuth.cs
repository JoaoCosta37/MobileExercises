using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        bool SignOut();
        bool IsSignIn();

        string AuthUser { get; }
    }
}
