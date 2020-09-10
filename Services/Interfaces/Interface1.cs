using DrivingSchool_Api;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Interfaces
{
   public interface IPackageInclusionService
    {
        bool Add(PackageInclusions packageInclusions);
        bool Delete(int? inclusionId);
        bool Update(PackageInclusions packageInclusions);
        IQueryable<PackageInclusions> GetAll();
        IQueryable<PackageInclusions> GetSingle(int? inclusionId);
        IQueryable<PackageInclusionVm> GetInclusionForPackage(int? bkpId);
    }
}
