using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class BillingDetailsRepository : IBillingDetailsRepository
{
    private readonly KaniniTourismDbContext _context;

    public BillingDetailsRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BillingDetails>> GetAllBillingDetails()
    {
        return await _context.BillingDetails.ToListAsync();
    }

    public async Task<BillingDetails?> GetBillingDetailsById(int id)
    {
        return await _context.BillingDetails.FindAsync(id);
    }

    public async Task<int> CreateBillingDetails(BillingDetails billingDetails)
    {
        _context.BillingDetails.Add(billingDetails);
        await _context.SaveChangesAsync();
        return billingDetails.BillingId;
    }

    public async Task<bool> UpdateBillingDetails(int id, BillingDetails billingDetails)
    {
        var existingBillingDetails = await _context.BillingDetails.FindAsync(id);
        if (existingBillingDetails == null)
            return false;

        // Update properties accordingly
        existingBillingDetails.BookingId = billingDetails.BookingId;
        existingBillingDetails.PackageID = billingDetails.PackageID;
        existingBillingDetails.BillingDate = billingDetails.BillingDate;
        existingBillingDetails.BillingAmount = billingDetails.BillingAmount;
        existingBillingDetails.PaymentMethod = billingDetails.PaymentMethod;
        existingBillingDetails.BillingStatus = billingDetails.BillingStatus;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBillingDetails(int id)
    {
        var billingDetails = await _context.BillingDetails.FindAsync(id);
        if (billingDetails == null)
            return false;

        _context.BillingDetails.Remove(billingDetails);
        await _context.SaveChangesAsync();
        return true;
    }
}
