using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EvidenceBasedScheduling.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        public const string JIRA_TOKEN_CLAIM = "jira-token";

        [HttpPost]
        public void Login(UserAuthRequest user)
        {
            //var jira = new Jira("http://localhost:8083", user.UserName, user.Password);
            //var token = jira.GetAccessToken();
            IAuthenticationManager authenticationManager = Request.GetOwinContext().Authentication;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie,
                ClaimTypes.NameIdentifier, ClaimTypes.Role);

            authenticationManager.SignIn(new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = user.RememberMe,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }

        public void Logout()
        {
            IAuthenticationManager authenticationManager = Request.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public class UserAuthRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }
    }
}