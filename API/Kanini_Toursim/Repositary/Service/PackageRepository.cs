using Kanini_Toursim.Model;
using System.Linq;

public class PackageRepository : IPackageRepository
{
    private readonly KaniniTourismDbContext _context;

    public PackageRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Package> GetAllPackages()
    {
        return _context.Packages.ToList();
    }

    public Package GetPackageById(int packageId)
    {
        return _context.Packages.FirstOrDefault(p => p.PackageID == packageId);
    }

    public void AddPackage(Package package)
    {
        _context.Packages.Add(package);
        _context.SaveChanges();
    }

    public void UpdatePackage(int packageId, Package updatedPackage)
    {
        var package = _context.Packages.FirstOrDefault(p => p.PackageID == packageId);
        if (package != null)
        {
            // Update the properties with the values from updatedPackage
            package.OfferingType = updatedPackage.OfferingType;
            package.Destination = updatedPackage.Destination;
            // Update other properties as needed

            _context.SaveChanges();
        }
    }

    public void DeletePackage(int packageId)
    {
        var package = _context.Packages.FirstOrDefault(p => p.PackageID == packageId);
        if (package != null)
        {
            _context.Packages.Remove(package);
            _context.SaveChanges();
        }
    }
}
