startRecognizing
	"Start recognizing phonemes from the sound input."

	self stopRecognizing.
	soundInput bufferSize: (PhonemeRecord fftSize).
	soundInput startRecording.
