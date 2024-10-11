using Blazored.Toast.Services;

namespace BlazorMAUIIdentity.Shared
{
    public static class Utilerias
    {
        public static string? Token { get; set; }
        public static class Toast
        {
            static ToastService toastService = new ToastService();
            public static void Warning(string message)
            {
                toastService.ShowWarning(message);
            }
            public static void Success(string message)
            {
                toastService.ShowSuccess(message);
            }
            public static void Error(string message)
            {
                toastService.ShowError(message);
            }
        }
    }
}
