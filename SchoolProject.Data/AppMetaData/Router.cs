

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "api";

        public static class Students
        {
            private const string Base = Root + "/students";
            public const string GetAll = Base;
            public const string GetById = Base + "/{id}";
            public const string Add = Base;
            public const string Update = Base;
            public const string Delete = Base + "/{id}";
        }

        public static class Departments
        {
            private const string Base = Root + "/departments";
            public const string GetById = Base + "/{id}";
            public const string GetStudentCount = Base + "/student-count";
        }

        public static class Users
        {
            private const string Base = Root + "/users";
            public const string GetAll = Base;
            public const string GetById = Base + "/{id}";
            public const string Add = Base;
            public const string Update = Base;
            public const string Delete = Base + "/{id}";
            public const string ChangePassword = Base + "/change-password";
            public const string SignIn = Base + "/sign-in";
            public const string RefreshToken = Base + "/refresh-token";
            public const string Register = Base + "/register";
        }

        public static class Authorization
        {
            private const string Base = Root + "/authorization";
            public const string AddRole = Base + "/add-role";
            public const string EditRole = Base + "/edit-role";
            public const string DeleteRole = Base + "/delete-role/{id}";
        }
    }
}
