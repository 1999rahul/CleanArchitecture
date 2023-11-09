using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Students.Command.CreateStudent;
public record CreateStudentCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Roll { get; set; }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateStudentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Student()
        {
            Name = request.Name,
            Age = request.Age,
            roll=request.Roll,
        };

        _context.Students.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
