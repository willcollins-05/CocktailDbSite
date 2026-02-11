namespace CocktailDbSite.Application.Services.WebpageServices;

public class ToastService
{
    public event Action<string, string>? OnShow;

    public void ShowToast(string title, string message)
    {
        OnShow!.Invoke(title, message);
    }
}