web   "Display restoreAfter: [Pen new web]"
	"Draw pretty web-like patterns from the mouse movement on the screen.
	Press the mouse button to draw, option-click to exit.
	By Dan Ingalls and Mark Lentczner. "
	| history newPoint ancientPoint lastPoint filter color |
	"self erase."
	color _ 1.
	[ true ] whileTrue:
		[ history _ SharedQueue new.
		Sensor waitButton.
		Sensor yellowButtonPressed ifTrue: [^ self].
		filter _ lastPoint _ Sensor mousePoint.
		20 timesRepeat: [ history nextPut: lastPoint ].
		self color: (color _ color + 1).
		[ Sensor redButtonPressed ] whileTrue: 
			[ newPoint _ Sensor mousePoint.
			(newPoint = lastPoint) ifFalse:
				[ ancientPoint _ history next.
				filter _ filter * 4 + newPoint // 5.
				self place: filter.
				self goto: ancientPoint.
				lastPoint _ newPoint.
				history nextPut: filter ] ] ]