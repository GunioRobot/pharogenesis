setVolume: aNumber 
	"changes the receiver's movie position"
	| newVolume |
	newVolume := aNumber asFloat min: 1.0 max: 0.0.
	self volumeSlider isNil ifFalse:[self volumeSlider value: newVolume].
	moviePlayer volume: newVolume