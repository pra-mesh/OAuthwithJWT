using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OAuthwithJWT.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet("google")]
    public IActionResult GoogleLogin()
    {
        Console.WriteLine("Test");
        var redirectURL = Url.Action(nameof(GoogleCallBack), "Auth");
        var properties = new AuthenticationProperties { RedirectUri = redirectURL };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
    [HttpGet("google-callback")]
    public async Task<IActionResult> GoogleCallBack()
    {
        Console.WriteLine("Test");
        var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (!result.Succeeded)
            return BadRequest("Google authentication failed");

        var claims = result.Principal?.Claims.ToList();
        var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        var providerId = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var picture = claims?.FirstOrDefault(c => c.Type == "picture")?.Value;
        if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(providerId))
        {
            return BadRequest("Required user information not available");
        }

        return Ok("Success");
    }
}
