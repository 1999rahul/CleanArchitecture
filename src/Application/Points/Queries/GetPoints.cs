using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Points.Queries;
public class GetPoints
{
    public record GetPointsQuery : IRequest<PointVM>;

    public class GetPointsQueryHandler : IRequestHandler<GetPointsQuery, PointVM>
    {
        public async Task<PointVM> Handle(GetPointsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PointVM() { x=10,y=20,z=10});
        }
    }
}
