﻿using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class TokenHandler
    {
        
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        //Token üretecek metot.
        public Token CreateAccessToken(User user)
        {
            Token tokenInstance = new Token()
            {
                //Oluşturulacak token ayarlarını veriyoruz.
                Expiration = DateTime.Now.AddMinutes(5)
            };

            //Security  Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],      //payload
                expires: tokenInstance.Expiration,//Token süresini 5 dk olarak belirliyorum
                notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
                signingCredentials: signingCredentials
            );

            //Token oluşturucu sınıfında bir örnek alıyoruz.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();


            //Token üretiyoruz.
            tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken); // JwtSecurityToken sınıfındaki bilgileri json formatına çevirir
                                                                                //gelen securityToken serialize edilir
            //Refresh Token üretiyoruz.
            tokenInstance.RefreshToken = CreateRefreshToken();
            return tokenInstance;
        }

        //Refresh Token üretecek metot.
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
