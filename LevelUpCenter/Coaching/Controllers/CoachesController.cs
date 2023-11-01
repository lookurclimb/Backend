using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Domain.Services;
using LevelUpCenter.Coaching.Resources.Coach;
using LevelUpCenter.Security.Authorization.Attributes;
using LevelUpCenter.Security.Domain.Services;
using LevelUpCenter.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LevelUpCenter.Coaching.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete coaches")]
public class CoachesController : ControllerBase
{
    private readonly ICoachService _coachService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CoachesController(ICoachService coachService, IUserService userService, IMapper mapper)
    {
        _coachService = coachService;
        _userService = userService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var coaches = await _coachService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Coach>, IEnumerable<CoachResource>>(coaches!);
            return Ok(resources);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RegisterRequest request)
    {

        var result = await _coachService.RegisterAsync(request);

        if (!result.Success)
            throw new Exception(result.Message);

        var coachResource = _mapper.Map<Coach, SaveCoachResource>(result.Resource);

        return Created("Successfully created", coachResource);
    }

    [HttpGet]
    [Route("{coachId:int}")]
    public async Task<CoachResource?> GetOneAsync(int coachId)
    {
        var coach = await _coachService.GetOneAsync(coachId);

        if (coach == null) return null;

        Console.WriteLine(coach.User);
        var resource = _mapper.Map<Coach, CoachResource>(coach);

        return resource;
    }
}
