using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.Models.Server.Core
{
    public static class Authorization
    {
        public static string AuthorizationToken;

        public async static Task<bool> Authorize()
        {
            // TODO: Check if saved token is still valid
            // TODO: Get saved token from the memory
            return false;
        }

        public async static Task<bool> SignIn(string identity, string password)
        {
            try
            {
                var token = await SupabaseService.SupabaseClient.Auth.SignIn(identity, password);
                // TODO: Save token into application memory

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while authorizing user details: {ex.Message}");
            }
        }
    }
}
