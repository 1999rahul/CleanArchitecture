using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MongoDB.Driver;

namespace CleanArchitecture.Application.Students.Command.CreateStudent;
public record CreateStudentCommand : IRequest<string>
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Roll { get; set; }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, string>
{
    private readonly IApplicationDbContext _context;
    private readonly IMongoCollection<Student> _students;

    public CreateStudentCommandHandler(IApplicationDbContext context, ISchoolDatabaseSettings settings)
    {
        _context = context;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentsCollectionName);
    }

    public async Task<string> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Student()
        {
            Name = request.Name,
            Age = request.Age,
            roll=request.Roll,
        };

        await _students.InsertOneAsync(entity);

        return entity.Id;
    }
}
