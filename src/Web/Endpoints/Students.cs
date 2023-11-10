
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Students.Command.CreateStudent;
using CleanArchitecture.Application.Students.Command.DeleteStudent;
using CleanArchitecture.Application.Students.Command.UpdateStudent;
using CleanArchitecture.Application.Students.Queries.GetStudents;
using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace CleanArchitecture.Web.Endpoints;

public class Students : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
       
           .MapGet(GetAllStudents)
           .MapPost(CreateStudent)
           .MapPut(UpdateStudent, "{id}")
           .MapDelete(DeleteStudent, "{id}");
    }

    public async Task<IEnumerable<StudentVM>> GetAllStudents(ISender sender)
    {
        return await sender.Send(new GetAllStudentsQuery());
    }

    public async Task<string> CreateStudent(ISender sender, CreateStudentCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateStudent(ISender sender, string id, UpdateStudentCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteStudent(ISender sender, string id)
    {
        await sender.Send(new DeleteStudentCommand(id));
        return Results.NoContent();
    }
}
