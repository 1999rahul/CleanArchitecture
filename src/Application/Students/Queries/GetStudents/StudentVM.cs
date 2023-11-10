using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using CleanArchitecture.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CleanArchitecture.Application.Students.Queries.GetStudents;
public class StudentVM
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public int roll { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Student, StudentVM>().ReverseMap();
            CreateMap<StudentVM, Student>().ReverseMap();
        }
    }
}
