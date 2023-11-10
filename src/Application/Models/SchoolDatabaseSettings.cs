using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Models;
public class SchoolDatabaseSettings : ISchoolDatabaseSettings
{
    public required string StudentsCollectionName { get; set; }
    public required string CoursesCollectionName { get; set; }
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}
public interface ISchoolDatabaseSettings
{
    string StudentsCollectionName { get; set; }
    string CoursesCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
