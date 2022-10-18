using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Country;
using Core.DTOs.Language;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountries() => _mapper.Map<IEnumerable<CountryDTO>>(await _unitOfWork.CountryRepository.GetAllAsync(include: source => source.Include(c => c.PhoneCodes)));
    }
}
