using System;
using System.Collections.Generic;

namespace Kanini_Toursim.Model
{
    public interface IPackageRepository
    {
        IEnumerable<Package> GetAllPackages();
        Package GetPackageById(int packageId);
        void AddPackage(Package package);
        void UpdatePackage(int packageId, Package updatedPackage);
        void DeletePackage(int packageId);
    }
}
