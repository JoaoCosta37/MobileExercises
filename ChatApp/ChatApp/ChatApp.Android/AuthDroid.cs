using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using ChatApp;
using ChatApp.Droid;
using ChatApp.Service;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]

namespace ChatApp.Droid
{
    public class AuthDroid : IAuth
    {

        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var tokenResult = await (FirebaseAuth.Instance.CurrentUser.GetIdToken(false).AsAsync<GetTokenResult>());



                return tokenResult.Token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }
    }
}