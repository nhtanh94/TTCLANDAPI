using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;

namespace AutoParking.Token
{
    public class TokenManager
    {
        public static string SECRET_KEY = "okOZ1sTIdzwSZlVvdKT2JLclKEW79FZN5SBGqKyGerglQ6ZtlTqGQ48PBE53Z9TOVyYFHpF9Hni+BltU9tJ+pQ==";
        public static string ISSUER = "gokiki.com";
        public static int EXPIRES_TIME = 30;//day

        public static string GenerateSecretKey()
        {
            return Convert.ToBase64String(new HMACSHA256().Key);
        }

        public static string GenerateTokenKey(string userName)
        {
            var issuedAt = DateTime.Now;
            var expires = DateTime.UtcNow.AddDays(7);

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) });

            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(SECRET_KEY));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            //Create token key
            var token = (JwtSecurityToken)tokenHandler.CreateJwtSecurityToken(
                   issuer: ISSUER,
                   audience: ISSUER,
                   subject: claimsIdentity,
                   notBefore: issuedAt,
                   expires: expires,
                   signingCredentials: signingCredentials
                );

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public static string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(EXPIRES_TIME);

            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            // var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:57987", audience: "http://localhost:57987",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}