testMouseTracking
	"A very simple example of drawing using the mouse. Compare the tracking speed of this example with that of testTabletTracking. Mouse down to draw a stroke, shift-mouse to exit."
	"Pen testMouseTracking"
	| pen p |
	pen := Pen newOnForm: Display.
	pen roundNib: 8.
	pen color: Color black.
	Display fillColor: Color white.
	Display restoreAfter: 
		[ [ Sensor shiftPressed and: [ Sensor anyButtonPressed ] ] whileFalse: 
			[ p := Sensor cursorPoint.
			Sensor anyButtonPressed 
				ifTrue: [ pen goto: p ]
				ifFalse: 
					[ pen color: Color random.
					pen place: p ] ] ]