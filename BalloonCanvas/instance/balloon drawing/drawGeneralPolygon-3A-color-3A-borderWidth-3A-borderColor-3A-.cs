drawGeneralPolygon: contours color: c borderWidth: borderWidth borderColor: borderColor
	"Draw a general polygon (e.g., a polygon that can contain holes)"
	| fillC borderC |
	fillC _ self shadowColor ifNil:[c].
	borderC _ self shadowColor ifNil:[borderColor].
	self ensuredEngine
		drawGeneralPolygon: contours
		fill: fillC
		borderWidth: borderWidth
		borderColor: borderC
		transform: transform.