using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MongoDB.Driver;

namespace CleanArchitecture.Application.Students.Queries.GetStudents;

public record GetAllStudentsQuery : IRequest<IEnumerable<StudentVM>>;
public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentVM>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Student> _students;

    public GetAllStudentsHandler(IApplicationDbContext context, IMapper mapper, ISchoolDatabaseSettings settings)
    {
        _context = context;
        _mapper = mapper;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentsCollectionName);
    }

    public async Task<IEnumerable<StudentVM>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var temp= await _students.Find(s => true).ToListAsync();
       // var res = await _context.Students.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<StudentVM>>(temp);   
    }
}
