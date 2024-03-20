using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Airline.API.Data.Repositories.Interfaces;
using Airline.API.Models.DTO;
using Airline.API.Models.Models.Domain;

namespace Airline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;
        private readonly ICustomerRepository customerRepository;
        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository,
            ICustomerRepository customerRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// Use this to register a new customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Request payload is invalid");
                }
                var user = new IdentityUser
                {
                    UserName = request.Email?.Trim(),
                    Email = request.Email?.Trim()
                };

                var identityResult = await userManager.CreateAsync(user, request.Password??string.Empty);

                if (identityResult.Succeeded)
                {
                    var customerRoles = new List<string> { "Customer" };
                    identityResult = await userManager.AddToRoleAsync(user, customerRoles.First());

                    if (identityResult.Succeeded)
                    {
                        CustomerDetails details = new CustomerDetails()
                        {
                            FName = request.FirstName,
                            LName = request.LastName,
                            UserId = user.Id
                        };

                        // Store customer details
                        await customerRepository.SaveCustomerDetailsAsync(details);

                        // Login the User after registration
                        var token = tokenRepository.CreateJwtToken(user, customerRoles);
                        var response = new LoginResponseDto
                        {
                            UserId = user.Id,
                            Email = request.Email,
                            Roles = customerRoles.ToList(),
                            Token = token
                        };

                        // Create a token
                        return Ok(response);
                    }
                    else
                    {
                        AddErrorsToModelState(identityResult.Errors);
                    }
                }
                else
                {
                    AddErrorsToModelState(identityResult.Errors);
                }

                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing the request."+ex.Message);
            }
        }

        private void AddErrorsToModelState(IEnumerable<IdentityError> errors)
        {
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    // Passing key is optional
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        /// <summary>
        /// Use this to login a existing customer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            try
            {
                // Check if the email exists
                var user = await userManager.FindByEmailAsync(request.Email ?? string.Empty);

                if (user is not null)
                {
                    // Check if the password is valid
                    var isValidPassword = await userManager.CheckPasswordAsync(user, request.Password ?? string.Empty);

                    if (isValidPassword)
                    {
                        // Get user roles
                        var roles = await userManager.GetRolesAsync(user);

                        // Create a JWT token
                        var token = tokenRepository.CreateJwtToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            UserId = user.Id,
                            Email = request.Email,
                            Roles = roles.ToList(),
                            Token = token
                        };

                        // Return the token in the response
                        return Ok(response);
                    }
                }

                ModelState.AddModelError("Email", "Invalid credentials");
                return ValidationProblem(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while processing the request."+ex.Message);
            }
        }
    }
}
