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
    protected override async void OnStart()
    {
        // Handle when your app starts
        WebSocketClient webSocketClient = new WebSocketClient();
        await webSocketClient.Connect();
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


