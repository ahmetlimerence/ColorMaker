using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
namespace ColorMaker;
public partial class MainPage : ContentPage
{
	bool _isRandom = false;

	public MainPage()
	{
		InitializeComponent();
	}
	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!_isRandom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
		
	}
	private void rndmBtnClicked (object sender, EventArgs e)
	{

		_isRandom = true;
            var random = new Random();
            Color color = Color.FromRgb(random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));
            SetColor(color);
            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
        _isRandom = false;
		
	}
	private async void imageBtnClicked (object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(lblHex.Text);
		var toast = Toast.Make("Color Coppied",
			CommunityToolkit.Maui.Core.ToastDuration.Short,
			12);
		await toast.Show();
	}

    private void SetColor(Color color)
	{
		Debug.WriteLine(color.ToString());
		btnRandomColor.BackgroundColor = color;
		Container.BackgroundColor = color;
		lblHex.Text = color.ToHex();
	}

	
}

