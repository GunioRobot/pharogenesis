testFMInteractively
	"Experiment with different settings of the FM modulation and multiplier settings interactively by moving the mouse. The top-left corner of the screen is 0 for both parameters. Stop when the mouse is pressed."
	"AbstractSound testFMInteractively"

	| s mousePt lastVal status |
	SoundPlayer startPlayerProcessBufferSize: 1100 rate: 22050 stereo: false.
	s _ FMSound pitch: 440.0 dur: 200.0 loudness: 200.
	s  decayRate: 1.0; modulationDecay: 1.0.

	SoundPlayer playSound: s.
	[Sensor anyButtonPressed] whileFalse: [
		mousePt _ Sensor cursorPoint.
		mousePt ~= lastVal ifTrue: [
			s modulation: mousePt x * 3 multiplier: mousePt y asFloat / 100.0.
			lastVal _ mousePt.
			status _
'mod: ', (mousePt x * 3) printString, '
mult: ', (mousePt y asFloat / 100.0) printString.
			status asParagraph displayOn: Display at: 10@10.
		].
	].
	SoundPlayer pauseSound: s.
