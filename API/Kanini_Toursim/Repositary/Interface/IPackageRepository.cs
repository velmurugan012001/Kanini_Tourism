using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetAllPackages();
    Task<Package> GetPackageById(int? id);
    Task<int> CreatePackage(Package package);
    Task<bool> UpdatePackage(int? id, Package package);
    Task<bool> DeletePackage(int? id);
}
