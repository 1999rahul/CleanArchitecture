
using CleanArchitecture.Application.Points.Queries;
using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using static CleanArchitecture.Application.Points.Queries.GetPoints;

namespace CleanArchitecture.Web.Endpoints;

public class Points : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetPoint);
            
    }

    public async Task<PointVM> GetPoint(ISender sender)
    {
        return await sender.Send(new GetPointsQuery());
    }
}
