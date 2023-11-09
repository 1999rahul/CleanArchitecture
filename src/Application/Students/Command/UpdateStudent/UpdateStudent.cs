using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;

namespace CleanArchitecture.Application.Students.Command.UpdateStudent;
public record UpdateStudentCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Roll { get; set; }
}

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Students
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Age = request.Age;
        entity.roll = request.Roll;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
