using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Mvc;

public interface IFeedbackRepository
{
    Task<IEnumerable<Feedback>> GetAllFeedbacks();

    Task<Feedback?> GetFeedbackById(int id);
    Task<int> CreateFeedback(Feedback feedback);
    Task<bool> UpdateFeedback(int id, Feedback feedback);
    Task<bool> DeleteFeedback(int id);
}
