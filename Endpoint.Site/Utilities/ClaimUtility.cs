using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Endpoint.Site.Utilities
{
    public static class ClaimUtility
    {
        public static long? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null)
                {
                    long userId = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return userId;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                return null;
            }

        }


        public static List<string> GetRoles(ClaimsPrincipal user)
        {

            try
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                List<string> rolse = new List<string>();
                foreach (var item in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
                {
                    rolse.Add(item.Value);
                }
                return rolse;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}



