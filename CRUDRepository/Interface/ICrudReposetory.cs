using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModels;

namespace CRUDRepository.Interface
{
    public interface ICrudReposetory
    {
        IEnumerable<CreateViewModel> GetAllStudent();
        void AddStudent(CreateViewModel student);

        void UpdateStudent(CreateViewModel student);
        CreateViewModel GetStudentData(int? id);

        void DeleteStudent(int? id);
    }
}
