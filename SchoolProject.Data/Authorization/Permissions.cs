namespace SchoolProject.Data.Authorization
{
    public static class Permissions
    {
        public static string Type { get; } = "permissions";

        // Student Permissions
        public const string AddStudent = "students.create";
        public const string UpdateStudent = "students.update";
        public const string DeleteStudent = "students.delete";
        public const string GetStudents = "students.read";

        // department Permissions
        public const string AddDepartment = "departments.create";
        public const string UpdateDepartment = "departments.update";
        public const string DeleteDepartment = "departments.delete";
        public const string GetDepartments = "departments.read";


        // return all permissions
        public static IList<string?> GetAllPermissions() =>
            typeof(Permissions).GetFields().Select(i => i.GetValue(i) as string).ToList();



    }
}
