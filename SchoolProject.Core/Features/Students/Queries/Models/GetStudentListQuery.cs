﻿using MediatR;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    //query=>response
    public class GetStudentListQuery : IRequest<List<Student>>
    {
    }
}
