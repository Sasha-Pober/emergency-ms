namespace Presentation.Controllers;

//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly UserManager<ApplicationUser> _userManager;
//    private readonly SignInManager<ApplicationUser> _signInManager;

//    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
//    {
//        _userManager = userManager;
//        _signInManager = signInManager;
//    }

//    [HttpPost("register")]
//    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
//    {
//        var user = new ApplicationUser { UserName = request.Username, Email = request.Email };
//        var result = await _userManager.CreateAsync(user, request.Password);
//        if (!result.Succeeded)
//            return BadRequest(result.Errors);

//        return Ok("User registered");
//    }

//    [HttpPost("login")]
//    public async Task<IActionResult> Login([FromBody] LoginRequest request)
//    {
//        var user = await _userManager.FindByEmailAsync(request.Email);
//        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
//            return Unauthorized();

//        await _signInManager.SignInAsync(user, true);

//        return Ok();
//    }

//    [HttpPost("logout")]
//    public async Task<IActionResult> Logout()
//    {
//        await _signInManager.SignOutAsync();
//        return Ok("Logged out");
//    }
//}
