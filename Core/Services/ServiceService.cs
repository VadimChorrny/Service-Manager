using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities.CategoryEntity;
using Core.Entities.SubscriptionEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using OfficeOpenXml;

namespace Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public async Task<bool> SaveFromExcel(string path)
        {
            try
            {
                foreach (var serviceItem in await _unitOfWork.ServiceRepository.GetAllAsync())
                {
                    if (!IsContainsInExcel(path, serviceItem))
                    {
                        var subSearch = (await _unitOfWork.SubscriptionsSearchRepository.GetFirstOrDefaultAsync(el => el.Service.Name == serviceItem.Name, disableTracking: false));
                        if (subSearch != null)
                        {
                            _unitOfWork.SubscriptionsSearchRepository.Delete(subSearch);
                        }
                        _unitOfWork.ServiceRepository.Delete(serviceItem);
                    }
                }
                using (var package = new ExcelPackage(path))
                {
                    var isContainsMainSheet = package.Workbook.Worksheets.Any(); //.Any(el => el.Name == "Main");
                    if (!isContainsMainSheet)
                    {
                        throw new HttpException("Mainsheet isn`t exists", System.Net.HttpStatusCode.BadRequest);
                    }

                    ExcelWorksheet mainSheet = package.Workbook.Worksheets[0];
                    for (int i = 2; i < mainSheet.Dimension.Rows; i++)
                    {
                        if (mainSheet.Cells[i, 1].Value != null && 
                            mainSheet.Cells[i, 3].Value != null && mainSheet.Cells[i, 4].Value != null &&
                            mainSheet.Cells[i, 6].Value != null)
                        //mainSheet.Cells[i, 2].Value != null &&
                        // mainSheet.Cells[i, 5].Value != null &&
                        {
                            string name = mainSheet.Cells[i, 1].Value as string;
                            string logo = mainSheet.Cells[i, 3].Value as string;
                            string categoryName = mainSheet.Cells[i, 4].Value as string;
                            string subCategoryName = mainSheet.Cells[i, 5].Value as string;
                            string searchField = mainSheet.Cells[i, 6].Value as string;
                            Service service = (await _unitOfWork.ServiceRepository.GetFirstOrDefaultAsync(el => el.Name == name, disableTracking: false));
                            if (service == null)
                            {
                                service = new Service { Name = name };
                                await _unitOfWork.ServiceRepository.Insert(service);
                            }

                            if (mainSheet.Cells[i, 6].Value != null)
                            {
                                string url = mainSheet.Cells[i, 2].Value as string;
                                service.Url = url;
                            }
                            ServiceCategory serviceCategory =
                                (await _unitOfWork.ServiceCategoryRepository.GetFirstOrDefaultAsync(el => el.Name == categoryName, disableTracking: false))
                                ;
                            if (serviceCategory == null)
                            {
                                serviceCategory = new ServiceCategory { Name = categoryName };
                                //serviceCategory =
                                await _unitOfWork.ServiceCategoryRepository.Insert(serviceCategory);
                            }

                            service.ServiceCategory = serviceCategory;
                            ServiceSubCategory serviceSubCategory =
                                (await _unitOfWork.ServiceSubCategoryRepository.GetFirstOrDefaultAsync(el => el.Name == subCategoryName, disableTracking: false))
                                ;
                            if (serviceSubCategory == null)
                            {
                                serviceSubCategory = new ServiceSubCategory { Name = subCategoryName };
                                //serviceCategory =
                                await _unitOfWork.ServiceSubCategoryRepository.Insert(serviceSubCategory);
                            }

                            service.ServiceSubCategory = serviceSubCategory;
                            service.Logo ??= logo;
                            var subscriptionsSearch =
                                (await _unitOfWork.SubscriptionsSearchRepository.GetFirstOrDefaultAsync(el => el.Service.Name == name, disableTracking: false))
                                ;
                            if (subscriptionsSearch == null)
                            {
                                subscriptionsSearch = new SubscriptionsSearch { Service = service };
                                await _unitOfWork.SubscriptionsSearchRepository.Insert(subscriptionsSearch);
                            }

                            subscriptionsSearch.Name = searchField;
                            if (mainSheet.Cells[i, 7].Value != null)
                            {
                                var phones = mainSheet.Cells[i, 7].Value;
                                //var phonesWithType 
                                List<SearchPhone> phonesStrings = null;
                                if (phones is double)
                                {
                                    //phones = ;
                                    phonesStrings = (Convert.ToDouble(phones).ToString(CultureInfo.InvariantCulture))?.Replace(" ", "").Split(',').Select(el => new SearchPhone{ Phone = el}).ToList();//.ToList();
                                }
                                else
                                {
                                    phonesStrings = ((string)phones)?.Replace(" ", "").Split(',').Select(el => new SearchPhone{ Phone = el}).ToList();//.ToList();

                                }
                                subscriptionsSearch.SearchPhones = phonesStrings; //. //= 
                            }
                            //await _unitOfWork.SubscriptionsSearchRepository.Insert(new SubscriptionsSearch {  Name= searchField, Service = service});
                            //_unitOfWork.ServiceCategoryRepository
                            await _unitOfWork.SaveChangesAsync();
                            //await _unitOfWork.BankRepository.SaveChangesAsync();
                        }

                        
                    }

                    
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message, HttpStatusCode.BadRequest);
            }

            finally
            {
                File.Delete(path);
            }
            
            
        }

        private bool IsContainsInExcel(string path,Service serviceItem)
        {
            using (var package = new ExcelPackage(path))
            {
                ExcelWorksheet mainSheet = package.Workbook.Worksheets[0];
                for (int i = 1; i < mainSheet.Dimension.Rows; i++)
                {
                    if (mainSheet.Cells[i, 1].Value as string == serviceItem.Name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
    }
}
