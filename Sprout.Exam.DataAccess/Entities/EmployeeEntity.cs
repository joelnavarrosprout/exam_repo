﻿namespace Sprout.Exam.DataAccess.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Birthdate { get; set; }
        public string Tin { get; set; }
        public int TypeId { get; set; }
    }
}