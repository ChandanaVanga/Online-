using Online.DTOs;
using Online.Models;
using Online.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Online.Controllers;

[ApiController]
[Route("api/tags")]
public class TagsController : ControllerBase
{
    private readonly ILogger<TagsController> _logger;
    private readonly ITagsRepository _tags;
    //private readonly ICustomerRepository _hardware;

    public TagsController(ILogger<TagsController> logger,
    ITagsRepository tags)
    {
        _logger = logger;
        _tags = tags;
       // _hardware = hardware;
    }

    // [HttpGet]
    // public async Task<ActionResult<List<TagsDTO>>> GetAllTags()
    // {
    //     var tagsList = await _tags.GetList();

    //     // User -> UserDTO
    //     var dtoList = tagsList.Select(x => x.asDto);

    //     return Ok(dtoList);
    // }

    [HttpGet("{tag_id}")]
    public async Task<ActionResult<TagsDTO>> GetById([FromRoute] long tag_id)
    {
        var tags = await _tags.GetById(tag_id);

        if (tags is null)
            return NotFound("No tag found with given tag id");

        // var dto = tags.asDto;

        // dto.Tags = (await _tags.GetListByTagId(tag_id)).Select(x => x.asDto).ToList();

        return Ok(tags);
    }

    [HttpPost]
    public async Task<ActionResult<TagsDTO>> CreateTags([FromBody] TagsCreateDTO Data)
    {
        // var tags = await _tags.GetById(Data.TagId);
        // if (tags is null)
        //     return NotFound("No tags found with given tag id");

        var toCreateTags = new Tags
        {
            TagName = Data.TagName.Trim(),
            Description = Data.Description,
            
        };

        var createdTags = await _tags.Create(toCreateTags);

        return StatusCode(StatusCodes.Status201Created, createdTags.asDto);
    }

    [HttpPut("{tag_id}")]
    public async Task<ActionResult> UpdateTags([FromRoute] long tag_id,
    [FromBody] TagsUpdateDTO Data)
    {
        var existing = await _tags.GetById(tag_id);
        if (existing is null)
            return NotFound("No tag found with given tag id");

        var toUpdateTags = existing with
        {
            TagName = Data.TagName?.Trim()?.ToLower() ?? existing.TagName,
            Description = existing.Description,
            Price = existing.Price,
            Status = existing.Status,
        };

        var didUpdate = await _tags.Update(toUpdateTags);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update tags");

        return NoContent();
    }

    [HttpDelete("{tag_id}")]
    public async Task<ActionResult> DeleteTags([FromRoute] long tag_id)
    {
        var existing = await _tags.GetById(tag_id);
        if (existing is null)
            return NotFound("No tags found with given tag id");

        var didDelete = await _tags.Delete(tag_id);

        return NoContent();
    }
}
