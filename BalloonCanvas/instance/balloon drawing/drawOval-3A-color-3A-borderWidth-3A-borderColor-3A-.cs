drawOval: r color: c borderWidth: borderWidth borderColor: borderColor
	"Draw the oval defined by the given rectangle"
	| fillC borderC |
	fillC _ self shadowColor ifNil:[c].
	borderC _ self shadowColor ifNil:[borderColor].
	self ensuredEngine
		drawOval: r
		fill: fillC
		borderWidth: borderWidth
		borderColor: borderC
		transform: transform.