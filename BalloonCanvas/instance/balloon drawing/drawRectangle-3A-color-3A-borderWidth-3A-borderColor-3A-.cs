drawRectangle: r color: c borderWidth: borderWidth borderColor: borderColor
	"Draw a rectangle"
	| fillC borderC |
	fillC _ self shadowColor ifNil:[c].
	borderC _ self shadowColor ifNil:[borderColor].
	self ensuredEngine
		drawRectangle: r
		fill: fillC
		borderWidth: borderWidth
		borderColor: borderC
		transform: transform.