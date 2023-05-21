using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
//using System.Web.Mvc;

namespace MVCAPI_OwinAuth.Controllers
{
    //[Authorize(Roles = "admins")]
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    //username
        //    //var b = HttpContext.Current.User.Identity.Name;
        //    //IEnumerable<Claim> claims = ((System.Security.Claims.ClaimsPrincipal)HttpContext.Current.User).Claims;
        //    ////// or
        //    //var a = claims.Where(x => x.Type == "Age").FirstOrDefault().Value;

        //    var identity = (ClaimsIdentity)User.Identity;
        //    var roles = identity.Claims
        //                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        //    var LogTime = identity.Claims
        //                .FirstOrDefault(c => c.Type == "LoggedOn").Value;

        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}

        [Authorize(Roles = "User")]
        [HttpGet]
        public IHttpActionResult Index12()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                //return new
                //{
                //    data = name
                //};
            }

            //ViewBag.Title = "Home Page";
            //var a = GetToken();
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Index()
        {
            //ViewBag.Title = "Home Page";
            var a = GetToken();
            return Ok(a);
        }


        //[AllowAnonymous]
        //[HttpGet]
        public Object GetToken()
        {
            string key = "E9DB7E89123F52A9F2DB04EF04C7FE88"; //Secret key which will be used later during validation    
            var issuer = "https://localhost:44361/";  //normally this will be your site URL    

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "bilal"));
            permClaims.Add(new Claim(ClaimTypes.Role, "User"));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
        }
    }
}
