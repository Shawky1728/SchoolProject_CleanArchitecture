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
        public const string CityMaxLength50 = "CityMaxLength50";
        public const string CountryMaxLength50 = "CountryMaxLength50";
        public const string InvalidEmailFormat = "InvalidEmailFormat";
        public const string PasswordComplexity = "PasswordComplexity";
        public const string EmailExists = "EmailExists";

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

        // department related messages
        public const string DepartmentNotFound = "DepartmentNotFound";
        public const string DepartmentRetrieved = "DepartmentRetrieved";
        public const string DepartmentsRetrieved = "DepartmentsRetrieved";
        public const string FailedToUpdateDepartment = "FailedToUpdateDepartment";
        public const string DepartmentUpdated = "DepartmentUpdated";
        public const string DepartmentDeleted = "DepartmentDeleted";
        public const string FailedToDeleteDepartment = "FailedToDeleteDepartment";
        public const string DepartmentAdded = "DepartmentAdded";

        // user related messages
        public const string UserNotFound = "UserNotFound";
        public const string UserRetrieved = "UserRetrieved";
        public const string UsersRetrieved = "UsersRetrieved";
        public const string FailedToUpdateUser = "FailedToUpdateUser";
        public const string UserUpdated = "UserUpdated";
        public const string UserDeleted = "UserDeleted";
        public const string FailedToDeleteUser = "FailedToDeleteUser";
        public const string UserAdded = "UserAdded";
        public const string FailedToAddUser = "FailedToAddUser";
        public const string FailedToChangePassword = "FailedToChangePassword";
        public const string InvalidCredentials = "InvalidCredentials";

        // Role related messages
        public const string RoleIsExist = "RoleIsExist";
        public const string RoleNotExist = "RoleNotExist";
        public const string AddRoleFailed = "AddRoleFailed";
        public const string RoleAdded = "RoleAdded";
        public const string EditRoleFailed = "EditRoleFailed";
        public const string RoleUpdated = "RoleUpdated";
        public const string DeleteRoleFailed = "DeleteRoleFailed";
        public const string RoleDeleted = "RoleDeleted";
    }
}
