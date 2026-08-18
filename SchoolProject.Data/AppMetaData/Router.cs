

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
        }
    }
}
