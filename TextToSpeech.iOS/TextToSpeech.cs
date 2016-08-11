using System;
using AVFoundation;

namespace TextToSpeech
{
	public class TextToSpeech
	{
		private AVSpeechSynthesizer _synth;
		private TextToSpeechConfig _config;

		public TextToSpeech(TextToSpeechConfig config) {
			SetConfig(config);
			_synth = new AVSpeechSynthesizer();
		}

		public void Speak(string text)
		{
			var speechUtterance = new AVSpeechUtterance(text)
			{
				Rate = _config.Rate,
				Voice = AVSpeechSynthesisVoice.FromLanguage(_config.Voice),
				Volume = _config.Volume,
				PitchMultiplier = _config.PitchMultiplier
			};

			_synth.SpeakUtterance(speechUtterance);
		}

		public void SetConfig(TextToSpeechConfig config)
		{
			if (null == config)
				throw new ArgumentNullException(nameof(config));
			_config = config;
		}
	}

	public class TextToSpeechConfig
	{
		public TextToSpeechConfig()
		{
			this.Rate = AVSpeechUtterance.MaximumSpeechRate / 2;
			this.Voice = "en-US";
			this.Volume = 1f;
			this.PitchMultiplier = 1f;
		}

		public float Rate { get; set; }
		public string Voice { get; set; }
		public float Volume { get; set; }
		public float PitchMultiplier { get; set; }
	}
}

