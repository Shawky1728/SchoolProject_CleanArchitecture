namespace SchoolProject.Core.Resources
{
    public static class SharedResourceKeys
    {
        public const string RequiredField = "RequiredField";

        // General response messages
        public const string Success = "Success";
        public const string Unauthorized = "Unauthorized";
        public const string Forbidden = "Forbidden";
        public const string BadRequest = "BadRequest";
        public const string NotFound = "NotFound";
        public const string CreatedSuccessfully = "CreatedSuccessfully";
        public const string DeletedSuccessfully = "DeletedSuccessfully";

        public const string ServerError = "ServerError";
        public const string UnProcessableEntity = "UnProcessableEntity";

        // Validation messages
        public const string NameMaxLength50 = "NameMaxLength50";
        public const string AddressMaxLength100 = "AddressMaxLength100";
        public const string PhoneFormat = "PhoneFormat";
        public const string DepartmentIdRange = "DepartmentIdRange";

        // student related messages
        public const string StudentNotFound = "StudentNotFound";
        public const string StudentRetrieved = "StudentRetrieved";
        public const string StudentsRetrieved = "StudentsRetrieved";
        public const string FailedToUpdateStudent = "FailedToUpdateStudent";
        public const string StudentUpdated = "StudentUpdated";
        public const string StudentDeleted = "StudentDeleted";
        public const string FailedToDeleteStudent = "FailedToDeleteStudent";
        public const string NameAlreadyExists = "NameAlreadyExists";
        public const string StudentAdded = "StudentAdded";
    }
}
