namespace OnlineLibrary.Business.Constants
{
    public static class Messages
    {
        public static string UserRegistered = "Kullanıcı başarılı bir şekilde kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string WrongPassword = "Parola hatası";
        public static string LoginSuccessful = "Başarılı giriş";
        public static string UserAlreadyExist = "Kullanıcı mevcut";
        public static string TokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserBookAdded = " isimli kitap eklendi!";
        public static string ReturnDateShouldBeAWeekAfterTheDay = "Kitabı iade tarihi, rezerve ettiği günden bir hafta sonra olmalıdır!";
        public static string UserIsNotAbleToRetrieveMoreThanThreeBooks = "Kullanıcı herhangi bir kitabı geri vermediğinden 3'ten fazla kitap alamaz!";
        public static string UserBookReserved = "Kullanıcı kitabı reserve edildi";
        public static string BookAlreadyExist = "Kitap zaten mevcut";
    }
}
