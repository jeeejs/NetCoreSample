using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PersonMicroservice.DBContexts;
using PersonMicroservice.Models;

namespace PersonMicroservice.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _dbContext;

        public PersonRepository(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeletePerson(long personId)
        {
            var person = _dbContext.Persons.Find(personId);
            _dbContext.Persons.Remove(person);
            Save();
        }

        public Person GetPersonByID(long personId)
        {
            return _dbContext.Persons.Find(personId);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _dbContext.Persons.ToList();
        }

        public void InsertPerson(Person person)
        {
            _dbContext.Add(person);
            Save();
        }

        public PersonAuth Login(Person person)
        {
            PersonAuth result = new PersonAuth();
            try
            {
                var mPerson = _dbContext.Persons.SingleOrDefault(p => p.Email == person.Email);
                if (mPerson == null || mPerson.Id < 1)
                {
                    result.Authenticated = false;
                    result.Error = "Email inválido !";
                }
                else if (mPerson.Password != person.Password)
                {
                    result.Authenticated = false;
                    result.Error = "Senha inválida !";
                }
                else
                {
                    result.Name = mPerson.Name;
                    result.Email = mPerson.Email;
                    result.Id = mPerson.Id;
                    result.Authenticated = true;
                    result.Token = GenerateToken(mPerson);
                }
            }
            catch (Exception ex)
            {
                result.Authenticated = false;
                result.Error = ex.Message;
            }
            return result;
        }

        private string GenerateToken(Person person)
        {
            string jwtIssuer = "SampleIssuer";
            string jwtAudience = "SampleAudience";
            string jwtKey = "secret-base-key-123213123";
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, person.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = jwtIssuer,
                ValidateAudience = true,
                ValidAudience = jwtAudience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };

            var jwt = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(5)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
            Save();
        }
    }
}
