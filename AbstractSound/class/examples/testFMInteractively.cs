testFMInteractively
	"Experiment with different settings of the FM modulation and multiplier settings interactively by moving the mouse. The top-left corner of the screen is 0 for both parameters. Stop when the mouse is pressed."
	"AbstractSound testFMInteractively"

	| s mousePt lastVal status mod mult |
	SoundPlayer startPlayerProcessBufferSize: 1100 rate: 11025 stereo: false.
	s _ FMSound pitch: 440.0 dur: 200.0 loudness: 0.2.

	SoundPlayer playSound: s.
	lastVal _ nil.
	[Sensor anyButtonPressed] whileFalse: [
		mousePt _ Sensor cursorPoint.
		mousePt ~= lastVal ifTrue: [
			mod _ mousePt x asFloat / 20.0.
			mult _ mousePt y asFloat / 20.0.
			s modulation: mod multiplier: mult.
			lastVal _ mousePt.
			status _
'mod: ', mod printString, '
mult: ', mult printString.
			status asParagraph displayOn: Display at: 10@10]].

	SoundPlayer shutDown.
