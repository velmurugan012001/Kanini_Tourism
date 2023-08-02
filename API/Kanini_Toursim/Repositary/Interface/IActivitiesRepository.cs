using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IActivitiesRepository
{
    Task<IEnumerable<Activities>> GetAllActivities();
    Task<Activities?> GetActivityById(int id);
    Task<int> CreateActivity(Activities activity);
    Task<bool> UpdateActivity(int id, Activities activity);
    Task<bool> DeleteActivity(int id);
}
