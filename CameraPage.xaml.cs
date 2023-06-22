using Camera.MAUI;

namespace HolaMundo;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
	}

    private async void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                if (await cameraView.StartCameraAsync() == CameraResult.Success)
                {
                }
            });
        }
    }

    public void onClickTomarFoto(object sender, EventArgs e)
    {

    }
}