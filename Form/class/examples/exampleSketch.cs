exampleSketch
	"This is a simple drawing algorithm to get a sketch on the display screen.
	Draws whenever mouse button down.  Ends with option-click."
	| aPen color |
	aPen _ Pen new.
	color _ 0.
	[Sensor yellowButtonPressed]
		whileFalse:
		[aPen place: Sensor cursorPoint; color: (color _ color + 1).
		[Sensor redButtonPressed]
			whileTrue: [aPen goto: Sensor cursorPoint]].
	Sensor waitNoButton.

	"Form exampleSketch"