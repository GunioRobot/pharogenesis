drawBoundsOn: aCanvas
	"Shows where line boundaries are"
	self paragraph lines do:
		[:line | aCanvas frameRectangle: line rectangle color: Color brown]
