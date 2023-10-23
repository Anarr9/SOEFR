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
        // Handle when your app sleeps
    }

    protected override void OnResume()
    {
        // Handle when your app resumes
    }
}


