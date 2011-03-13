playback
	"Playback the sound that has been recorded."

	self pause.
	soundPlaying _ self recordedSound ifNil: [^self].
	soundPlaying play.
