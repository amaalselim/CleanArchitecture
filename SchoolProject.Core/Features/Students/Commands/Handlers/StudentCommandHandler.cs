using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<CreateStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region handle Functions
        public async Task<Response<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //Mapping between request and student
            var studentmapper=_mapper.Map<Student>(request);
            //add
            var result=await _studentService.AddAsync(studentmapper);
            //check condition
            if (result.Equals("Exist"))
            {
                return UnProcessableEntity<string>("Student with this name already exists");
            }
            else if (result.Equals("Success"))
            {
                return Created<string>("Added Successfully");
            }
            //return response
            else return BadRequest<string>("Something went wrong, please try again later");
        }
        #endregion
    }
}
