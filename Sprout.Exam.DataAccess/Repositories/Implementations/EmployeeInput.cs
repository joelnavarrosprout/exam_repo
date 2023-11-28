using System;

namespace Sprout.Exam.DataAccess.Repositories.Implementations
{
    public class EmployeeInput
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public int TypeId { get; set; }
    }
}