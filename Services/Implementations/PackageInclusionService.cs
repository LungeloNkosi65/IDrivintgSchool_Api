using DrivingSchool_Api;
using Models.ViewModels;
using Repository.Implementations;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class PackageInclusionService : IPackageInclusionService
    {
        private IPackageInclusionRepository _packageInclusionRepository;

        public PackageInclusionService(IPackageInclusionRepository packageInclusionRepository)
        {
            _packageInclusionRepository = packageInclusionRepository;
        }
        public bool Add(PackageInclusions packageInclusions)
        {
            return _packageInclusionRepository.Add(packageInclusions);
        }

        public bool Delete(int? inclusionId)
        {
            return _packageInclusionRepository.Delete(inclusionId);
        }

        public IQueryable<PackageInclusions> GetAll()
        {
            return _packageInclusionRepository.GetAll();
        }

        public IQueryable<PackageInclusionVm> GetInclusionForPackage(int? bkpId)
        {
            return _packageInclusionRepository.GetInclusionForPackage(bkpId);
        }

        public IQueryable<PackageInclusions> GetSingle(int? inclusionId)
        {
            return _packageInclusionRepository.GetSingleRecord(inclusionId);
        }

        public bool Update(PackageInclusions packageInclusions)
        {
            return _packageInclusionRepository.Update(packageInclusions);
        }
    }
}
