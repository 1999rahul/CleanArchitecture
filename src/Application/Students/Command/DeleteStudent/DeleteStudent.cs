using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.TodoLists.Commands.DeleteTodoList;
using CleanArchitecture.Domain.Entities;
using MongoDB.Driver;

namespace CleanArchitecture.Application.Students.Command.DeleteStudent;

public record DeleteStudentCommand(string Id) : IRequest;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMongoCollection<Student> _students;

    public DeleteStudentCommandHandler(IApplicationDbContext context, ISchoolDatabaseSettings settings)
    {
        _context = context;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _students = database.GetCollection<Student>(settings.StudentsCollectionName);
    }

    public async Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        /*var entity = await _context.Students
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Students.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);*/

        await _students.DeleteOneAsync(s => s.Id == request.Id);
    }
}
