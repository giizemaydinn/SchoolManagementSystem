using Entities.Dtos.Parent;
using Entities.Dtos.Teacher;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddStudent = "Öğrenci eklendi.";
        public static string GetAllStudent = "Öğrenciler listelendi.";

        public static string AddParent = "Veli eklendi.";
        public static string GetAllParent = "Veliler listelendi.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string GetTeacher = "Öğretmen getirildi.";

        public static string AddUserOperationClaim = "Yetki eklendi.";
        public static string AddUser = "Kullanıcı eklendi.";
        public static string GetByMail = "Kullanıcı getirildi.";
        public static string AddTeacher = "Öğretmen eklendi.";
        public static string GetAllTeacher = "Öğretmenler listelendi.";
        public static string AddLesson = "Ders eklendi.";
        public static string GetAllLesson = "Dersler listelendi.";
        public static string AddExamGrade = "Sınav notu eklendi.";
        public static string GetAllExamGrade = "Sınav notları listelendi.";
        public static string GetStudent = "Öğrenci getirildi.";
        public static string GetStudentError = "Öğrenci bulunamadı.";
        public static string GetParent = "Veli getirildi.";
        public static string PasswordLengthError = "Şifre 8 karakterden uzun olmalıdır.";

        public static string EmailError = "Geçersiz email adresi girdiniz.";
        public static string PasswordContainsLowerCaseError = "Şifre en az bir küçük harf içermelidir.";
        public static string PasswordContainsUpperCaseError = "Şifre en az bir büyük harf içermelidir.";
        public static string PasswordContainsNumberError = "Şifre en az bir rakam içermelidir.";
        public static string PasswordContainsSymbolCharError = "Şifre en az bir özel karakter içermelidir.";
        public static string StartWithInvalidChar = "Geçersiz bilgi girişi yapıldı.";
        public static string DataOfUserExistsError = "Kullanıcıyla ilişkili veriler bulunduğundan silinemez.";
        public static string GetByMailError = "Email bulunamadı.";
        public static string SuccessLogin = "Login başarılı";
        public static string EmailExistsError = "Email adresi mevcut.";
        public static string ParentExistsError = "Veli bilgisi bulunamadı.";
        public static string GetParentError = "Veli bilgisi getirilemedi.";
        public static string GetLesson = "Ders bilgisi getirildi.";
        public static string GetLessonError = "Ders bilgisi getirilemedi.";
        public static string LessonNameExistsError = "Ders adı daha önce eklenmiş.";
        public static string GetTeacherError = "Öğretmen bulunamadı.";
    }
}
