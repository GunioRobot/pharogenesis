drawPolygon: vertices fillStyle: aFillStyle borderWidth: borderWidth borderColor: borderColor
	"Draw a simple polygon defined by the list of vertices."
	| fillC borderC |
	fillC _ self shadowColor ifNil:[aFillStyle].
	borderC _ self shadowColor ifNil:[borderColor].
	self ensuredEngine
		drawPolygon: (vertices copyWith: vertices first)
		fill: fillC
		borderWidth: borderWidth
		borderColor: borderC
		transform: transform.