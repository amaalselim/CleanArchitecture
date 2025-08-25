using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                         IRequestHandler<CreateStudentCommand, Response<string>>,
                                         IRequestHandler<EditStudentCommand, Response<string>>,
                                         IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region handle Functions
        public async Task<Response<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            //Mapping between request and student
            var studentmapper = _mapper.Map<Student>(request);
            //add
            var result = await _studentService.AddAsync(studentmapper);
            //check condition
            if (result.Equals("Success"))
            {
                return Created<string>("Added Successfully");
            }
            else return BadRequest<string>("Something went wrong, please try again later");
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if id exists or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<string>("Student Not Found");
            //mapping between request and student
            var studentmapper = _mapper.Map<Student>(request);
            //call service to make edit
            var result = await _studentService.EditAsync(studentmapper);
            //return response
            if (result.Equals("Success"))
            {
                return Created<string>($"ID Number {studentmapper.StudID} Edit Successfully");
            }
            else return BadRequest<string>("Something went wrong, please try again later");
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if id exists or not
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<string>("Student Not Found");
            //make delete
            var result = await _studentService.DeleteAsync(student.StudID);
            //return response
            if (result.Equals("Success"))
            {
                return Deleted<string>();
            }
            else return BadRequest<string>("Something went wrong, please try again later");
        }
        #endregion
    }
}
