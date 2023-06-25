using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        public IActionResult UserLogin([FromForm] UserDTO login)
        {
            var dao = new UserDAO();
            var usuario = dao.LoginUsuario(login);

            if (usuario.ID == 0)
            {
                return NotFound("Usuario e/ou senha invalidos");
            }

            var token = GenerateJwtToken(usuario, "PU8a9W4sv2opkqlOwmgsn3w3Innlc4D5");
            return Ok(new { token });
        }

        [HttpPost]
        [Route("LoginWorker")]
        public IActionResult WorkerLogin([FromForm] TrabalhadorDTO login)
        {
            var dao = new TrabalhadorDAO();
            var usuario = dao.LoginTrabalhador(login);

            if(usuario.ID == 0)
            {
                return NotFound("Usuario e/ou senha invalidos");
            }

            var token = GenerateJwtToken2(usuario, "PU8a9W4sv2opkqlOwmgsn3w3Innlc4D5");
            return Ok(new { token });
        }

        string GenerateJwtToken(UserDTO usuario, string secretKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("ID", usuario.ID.ToString()),
                new Claim("Email", usuario.Email),
                new Claim("Senha", usuario.Senha),
                new Claim("Nome", usuario.Nome),
                new Claim("SobreNome", usuario.SobreNome)
            };

            var token = new JwtSecurityToken(
                "MyService",
                "MyService",
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        string GenerateJwtToken2(TrabalhadorDTO usuario, string secretKey)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("ID", usuario.ID.ToString()),
                new Claim("Nome", usuario.Nome),
                new Claim("Empresa", usuario.Empresa),
                new Claim("Cpf_Cnpj", usuario.CPF_CNPJ),
                new Claim("Telefone", usuario.Telefone),
                new Claim("Instagram", usuario.Instagram),
                new Claim("Email", usuario.Email),
                new Claim("Senha", usuario.Senha),
                new Claim("Acesso", usuario.Acesso),
                new Claim("Imagem", usuario.Imagem),
            };

            var token = new JwtSecurityToken(
                "MyService",
                "MyService",
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("Cadastro")]
        public IActionResult Cadastrar(UserDTO user)
        {
            UserDAO dao = new UserDAO();
            dao.CadastroUsuario(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("CadastroWorker")]
        public IActionResult Cadastrar(TrabalhadorDTO work)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.CadastroTrabalhador(work);
            return Ok(work);
        }
    }
}
