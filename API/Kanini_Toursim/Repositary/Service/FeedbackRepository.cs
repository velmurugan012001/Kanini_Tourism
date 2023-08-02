using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly KaniniTourismDbContext _context;

    public FeedbackRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
    {
        return await _context.Feedback.ToListAsync();
    }

    public async Task<Feedback?> GetFeedbackById(int id)
    {
        return await _context.Feedback.FindAsync(id);
    }

    public async Task<int> CreateFeedback(Feedback feedback)
    {
        _context.Feedback.Add(feedback);
        await _context.SaveChangesAsync();
        return feedback.Id;
    }

    public async Task<bool> UpdateFeedback(int id, Feedback feedback)
    {
        var existingFeedback = await _context.Feedback.FindAsync(id);
        if (existingFeedback == null)
            return false;

        // Update properties accordingly
        existingFeedback.TravelerId = feedback.TravelerId;
        existingFeedback.TripId = feedback.TripId;
        existingFeedback.HotelId = feedback.HotelId;
        existingFeedback.Rating = feedback.Rating;
        existingFeedback.Comments = feedback.Comments;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteFeedback(int id)
    {
        var feedback = await _context.Feedback.FindAsync(id);
        if (feedback == null)
            return false;

        _context.Feedback.Remove(feedback);
        await _context.SaveChangesAsync();
        return true;
    }
}
