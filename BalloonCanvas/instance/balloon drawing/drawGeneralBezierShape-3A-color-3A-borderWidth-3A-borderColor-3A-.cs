drawGeneralBezierShape: contours color: c borderWidth: borderWidth borderColor: borderColor
	"Draw a general boundary shape (e.g., possibly containing holes)"
	| fillC borderC |
	fillC _ self shadowColor ifNil:[c].
	borderC _ self shadowColor ifNil:[borderColor].
	self ensuredEngine
		drawGeneralBezierShape: contours
		fill: fillC
		borderWidth: borderWidth
		borderColor: borderC
		transform: transform.