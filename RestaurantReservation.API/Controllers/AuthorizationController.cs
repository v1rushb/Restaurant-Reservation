using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Services.Interfaces;
using RestaurantReservation.API.Utilities;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IValidator<UserWithoutIdDTO> _userRegistrationValidator;
        private readonly IValidator<UserLoginDTO> _userLoginValidator;
        private readonly IUserService _userService;

         public AuthorizationController(
            IUserService userService,
            IMapper mapper,
            ITokenGenerator tokenGenerator,
            IValidator<UserWithoutIdDTO> userWithoutIdValidator,
            IValidator<UserLoginDTO> userLoginValidator)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
            _userRegistrationValidator = userWithoutIdValidator;
            _userLoginValidator = userLoginValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserWithoutIdDTO userRegister)
        {
            var validatedResult = await _userRegistrationValidator.ValidateAsync(userRegister);

            if(!validatedResult.IsValid)
            {
                    return BadRequest(ApiResponseHelper.CreateErrorResponse<string>(
                    validatedResult.Errors.Select(e => new ValidationResultDTO
                    {
                        ErrorMessage = e.ErrorMessage,
                        PropertyName = e.PropertyName,
                        AttemptedValue = e.AttemptedValue?.ToString()
                    }).ToList()));
            }

            var user = _mapper.Map<User>(userRegister);
            
            try {
                await _userService.CreateAsync(user);
            }
            catch (UsernameDuplicateException ex)
            {
                return BadRequest(ex.Message);
            }

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            var response = new {Token = token};
            return Ok(ApiResponseHelper.CreateSuccessResponse(new { Token = token }));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDTO userLogin)
        {
            var validationResult = await _userLoginValidator.ValidateAsync(userLogin);

            if(!validationResult.IsValid)
            {
                return BadRequest(ApiResponseHelper.CreateErrorResponse<string>(
                    validationResult.Errors.Select(e => new ValidationResultDTO
                    {
                        ErrorMessage = e.ErrorMessage,
                        PropertyName = e.PropertyName,
                        AttemptedValue = e.AttemptedValue?.ToString()
                    }).ToList()));
            }

            var user = await _userService
                .AuthenticateUserAsync(userLogin.Username, userLogin.Password);
            
            if(user == null)
                return Unauthorized(ApiResponseHelper.CreateErrorResponse<string>(
                    new List<ValidationResultDTO>
                    {
                        new() { ErrorMessage = "Invalid username or password." }
                    }));

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            var response = new {Token = token};
            return Ok(ApiResponseHelper.CreateSuccessResponse(response));
        }
    }
}