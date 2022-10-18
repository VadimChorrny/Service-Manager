using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Language;
using Core.Interfaces;
using Core.Interfaces.CustomServices;

namespace Core.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LanguageDTO>> GetAllLanguages() => _mapper.Map<IEnumerable<LanguageDTO>>(await _unitOfWork.LanguageRepository.GetAllAsync());
        
    }
}
