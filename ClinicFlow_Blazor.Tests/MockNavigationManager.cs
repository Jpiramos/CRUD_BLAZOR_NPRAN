using Microsoft.AspNetCore.Components;

public class MockNavigationManager : NavigationManager
{
    public MockNavigationManager()
    {
        Initialize("http://localhost/", "http://localhost/");
    }

    public string NavigatedUri { get; private set; }
    public NavigationOptions NavigatedOptions { get; private set; }

    protected override void NavigateToCore(string uri, NavigationOptions options)
    {
        NavigatedUri = uri;
        NavigatedOptions = options;
    }
}
