using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using upgradedfis.Models;


[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly NotificationService _notificationService;

    public NotificationController(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Notification>>> GetAllNotifications()
    {
        var notifications = await _notificationService.GetAllNotificationsAsync();
        return Ok(notifications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Notification>> GetNotificationById(long id)
    {
        var notification = await _notificationService.GetNotificationByIdAsync(id);
        if (notification == null)
        {
            return NotFound();
        }
        return Ok(notification);
    }

    [HttpPost]
    public async Task<ActionResult> AddNotification([FromBody] NotificationDto notificationDto)
    {
        if (notificationDto == null)
        {
            return BadRequest();
        }

        await _notificationService.AddNotificationAsync(notificationDto);
        return CreatedAtAction(nameof(GetNotificationById), new { id = notificationDto.Id }, notificationDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateNotification(long id, [FromBody] NotificationDto notificationDto)
    {
        if (notificationDto == null || id != notificationDto.Id)
        {
            return BadRequest();
        }

        await _notificationService.UpdateNotificationAsync(notificationDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteNotification(long id)
    {
        await _notificationService.DeleteNotificationAsync(id);
        return NoContent();
    }
}
