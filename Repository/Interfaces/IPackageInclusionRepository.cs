using DrivingSchool_Api;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
   public interface IPackageInclusionRepository
    {
        bool Add(PackageInclusions packageInclusions);
        bool Delete(object id);
        bool Update(PackageInclusions packageInclusions);
        IQueryable<PackageInclusions> GetAll();
        IQueryable<PackageInclusions> GetSingleRecord(object id);
        IQueryable<PackageInclusionVm> GetInclusionForPackage(int? bkpId);
    }
}
