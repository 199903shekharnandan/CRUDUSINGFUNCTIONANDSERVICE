using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModels;

namespace CRUDService.Interface
{
    public interface ICreateService
    {
        //CreateViewModel
        Task<List<CreateViewModel>> GetAllDetails();

        Task<List<CreateViewModel>> CreateAllDetails(CreateViewModel student);

        Task<bool> DeleteStudentAsync(int? id);

        Task<CreateViewModel> GetDataBasedOnId(int? id);

        Task<CreateViewModel> UpdateData(CreateViewModel createViewModel);
    }
}
