using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using upgradedfis.Models;

public class NotificationService
{
    private readonly ApplicationDbContext _context;

    public NotificationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Notification>> GetAllNotificationsAsync()
    {
        return await _context.Notifications.ToListAsync();
    }

    public async Task<Notification> GetNotificationByIdAsync(long id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task AddNotificationAsync(NotificationDto notificationDto)
    {
        var notification = new Notification
        {
            WorkId = notificationDto.WorkId,
            Title = notificationDto.Title,
            Message = notificationDto.Message,
            Date = notificationDto.Date,
            EmployeeId = notificationDto.EmployeeId
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNotificationAsync(NotificationDto notificationDto)
    {
        var existingNotification = await _context.Notifications.FindAsync(notificationDto.Id);
        if (existingNotification != null)
        {
            existingNotification.WorkId = notificationDto.WorkId;
            existingNotification.Title = notificationDto.Title;
            existingNotification.Message = notificationDto.Message;
            existingNotification.Date = notificationDto.Date;
            existingNotification.EmployeeId = notificationDto.EmployeeId;

            _context.Notifications.Update(existingNotification);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteNotificationAsync(long id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification != null)
        {
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
    }
}
