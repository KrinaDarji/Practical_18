using Practical_18.Contracts;
using Practical_18.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Repositories
{
    public class StudentRepository : GenericRepositories<Student>, IStudentRepository

    {
        public StudentRepository(ApplicationDBcontext context) : base(context)
        {
        }
    }
}
