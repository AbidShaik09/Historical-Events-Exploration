using NuGet.Common;

namespace ARHEEWebAPI
{
    public class TokenAuthenticator
    {
        public bool Authenticate( string token)
        {
            string accessToken = decode(token);
            string[] userToken = accessToken.Split("validTill");
            if (userToken.Length < 2)
            {
                return false;
            }
            DateTime t = DateTime.Parse(userToken[1]);
            if ( t >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




        public string GenerateAuthToken(string username)
        {
            DateTime d = DateTime.Now;
            d = d.AddHours(6);

            string accessToken = username + "validTill" + (d);
            accessToken = "accessToken:" + encode(accessToken);
            return accessToken;
        }

        public string getUserNameFromAccessToken(string token)
        {

            string accessToken = decode(token);
            string[] userToken = accessToken.Split("validTill");
            return userToken[0];

        }





        private string encode(string raw)
        {
            char[] chars = raw.ToCharArray();

            string s = "";
            for (int i = 0; i < chars.Length; i++)
            {
                if (i % 2 == 0)
                {
                    chars[i] = (char)(chars[i] + 21);
                }
                else
                {

                    chars[i] = (char)(chars[i] + 80);
                }
                s += chars[i];

            }
            return s;

        }
        private string decode(string raw)
        {
            try
            {
                char[] chars = raw.Split(':')[1].ToCharArray();
                string s = "";

                for (int i = 0; i < chars.Length; i++)
                {


                    if (i % 2 == 0)
                    {
                        chars[i] = (char)(chars[i] - 21);
                    }
                    else
                    {
                        chars[i] = (char)(chars[i] - 80);
                    }
                    s += chars[i];

                }
                return s;
            }
            catch (Exception e)
            {
                return "Invalid Token";
            }
        }
    






    }
}
