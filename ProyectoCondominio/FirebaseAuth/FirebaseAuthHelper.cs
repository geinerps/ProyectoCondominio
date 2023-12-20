using Firebase.Auth.Providers;
using Firebase.Auth;

namespace ProyectoCondominio.FirebaseAuth
{
    public class FirebaseAuthHelper
    {
        public const string firebaseAppId = "condominio-d5aa9";
        public const string firebaseApiKey = "AIzaSyDWqb1VCreD9Ot9lsGyRRDj5Gt8HS9hlN8";

        public static FirebaseAuthClient setFirebaseAuthClient()
        {
            var response = new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey = firebaseApiKey,
                AuthDomain = $"{firebaseAppId}.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()
                    }
            });

            return response;
        }
    }
}

