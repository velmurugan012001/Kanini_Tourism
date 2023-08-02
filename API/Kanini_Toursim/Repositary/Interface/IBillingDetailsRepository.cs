using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IBillingDetailsRepository
{
    Task<IEnumerable<BillingDetails>> GetAllBillingDetails();
    Task<BillingDetails?> GetBillingDetailsById(int id);
    Task<int> CreateBillingDetails(BillingDetails billingDetails);
    Task<bool> UpdateBillingDetails(int id, BillingDetails billingDetails);
    Task<bool> DeleteBillingDetails(int id);
}
