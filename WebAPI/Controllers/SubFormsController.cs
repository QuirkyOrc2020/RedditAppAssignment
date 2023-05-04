using Application.DaoInterfaces;
using Application.LogicInterfaces;

using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SubFormsController : ControllerBase
{
    private readonly ISubForumLogic subForumLogic;
    private readonly ISubForumDao SubForumDao;

    public SubFormsController(ISubForumLogic subForumLogic, ISubForumDao dao)
    {
        this.subForumLogic = subForumLogic;
        this.SubForumDao = dao;
    }

    [HttpPost]
    public async Task<ActionResult<SubForum>> CreateAsync([FromBody]SubForumCreationDto subForumCreationDto)
    {
        try
        {
            SubForum subForum = await subForumLogic.CreateAsync(subForumCreationDto);
            return Created($"/subForms/{subForum.Id}", subForum);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<SubForum>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
         SubForum subForums = await SubForumDao.GetByIdAsync(id);
            return Ok(subForums);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] SubForumUpdateDto subForumUpdateDto)
    {
        try
        {
            await subForumLogic.UpdateAsync(subForumUpdateDto);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync([FromQuery] int id)
    {
        try
        {
            await subForumLogic.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}