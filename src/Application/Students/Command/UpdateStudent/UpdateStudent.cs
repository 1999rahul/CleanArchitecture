using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CleanArchitecture.Application.Students.Command.UpdateStudent;
public record UpdateStudentCommand : IRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Roll { get; set; }
}

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMongoCollection<Student> _students;

    public UpdateStudentCommandHandler(IApplicationDbContext context, ISchoolDatabaseSettings settings)
    {
        _context = context;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentsCollectionName);
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        /*var entity = await _context.Students
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Age = request.Age;
        entity.roll = request.Roll;*/

        //await _context.SaveChangesAsync(cancellationToken);

        await _students.ReplaceOneAsync(s => s.Id == request.Id, new Student() { Id=request.Id, Age=request.Age,roll=request.Roll,Name=request.Name});
    }
}
