setPosition: aNumber 
	"changes the receiver's movie position"
	| newPosition |
	newPosition := aNumber asFloat min: 1.0 max: 0.0.
	positionSlider value: newPosition.
	moviePlayer moviePosition: newPosition