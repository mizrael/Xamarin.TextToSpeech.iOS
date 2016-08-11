using System;

using UIKit;

namespace TextToSpeech.iOS
{
	public partial class ViewController : UIViewController
	{
		private TextToSpeech _speaker;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_speaker = new TextToSpeech(new TextToSpeechConfig());

			this.btnPlay.TouchUpInside += (sender, e) => {
				var text = this.txtMessage.Text;
				if (string.IsNullOrWhiteSpace(text))
					return;
				_speaker.Speak(text);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

