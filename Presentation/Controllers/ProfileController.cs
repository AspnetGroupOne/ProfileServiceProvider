using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController(ProfileService profileService) : ControllerBase
{
    private readonly ProfileService _profileService = profileService;

    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileReqeustForm request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var res = await _profileService.CreateAsync(request);

        return res.Success ? Ok() : BadRequest();

    }


    [HttpPatch]
    public async Task<IActionResult> UpdateProfile(UpdateProfileRequestForm request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var res = await _profileService.UpdateAsync(request);
        return res.Success ? Ok() : BadRequest();


    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProfile(string id)
    {
        if(string.IsNullOrWhiteSpace(id))
        {
            return BadRequest();
        }

        var res = await _profileService.GetByIdAsync(id);
        return res.Success ? Ok(res.Object) : NotFound();
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteProfile(string id)
    {
        var res = await _profileService.DeleteByIdAsync(id);
        return res == null ? NotFound() : Ok();
    }
}