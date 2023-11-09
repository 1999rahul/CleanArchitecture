using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Students.Queries.GetStudents;

public record GetAllStudentsQuery : IRequest<IEnumerable<StudentVM>>;
public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentVM>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllStudentsHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentVM>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Students.ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<StudentVM>>(res);   
    }
}
