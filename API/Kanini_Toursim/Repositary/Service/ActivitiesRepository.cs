/*using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class ActivitiesRepository : IActivitiesRepository
{
    private readonly KaniniTourismDbContext _context;

    public ActivitiesRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Activities>> GetAllActivities()
    {
        return await _context.Activities.ToListAsync();
    }

    public async Task<Activities?> GetActivityById(int id)
    {
        return await _context.Activities.FindAsync(id);
    }

    public async Task<int> CreateActivity(Activities activity)
    {
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
        return activity.ActivitiesId; // Change 'ActivityId' to 'ActivitiesId'
    }


    public async Task<bool> UpdateActivity(int id, Activities activity)
    {
        var existingActivity = await _context.Activities.FindAsync(id);
        if (existingActivity == null)
            return false;

        // Update properties accordingly
        existingActivity.Name = activity.Name;
        existingActivity.Description = activity.Description;
        existingActivity.Duration = activity.Duration;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteActivity(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity == null)
            return false;

        _context.Activities.Remove(activity);
        await _context.SaveChangesAsync();
        return true;
    }
}
*/