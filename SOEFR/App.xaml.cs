namespace SOEFR;

public partial class App : Application
{

    public static WebSocketClient WebSocketClient { get; private set; }
    
    public App()
	{
		InitializeComponent();
        WebSocketClient = new WebSocketClient();
        MainPage = new Views.BottomTabPage();
	}
    protected override void OnStart()
    {
        // Handle when your app starts

    }

    protected override void OnSleep()
    {
        // App sleeps
    }

    protected override void OnResume()
    {
        // App resumes
    }
}


