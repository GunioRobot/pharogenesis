drawOn: aCanvas
	"Note: Set 'drawAsRect' to true to make the atoms draw faster. When testing the speed of other aspects of Morphic, such as its damage handling efficiency for large numbers of atoms, it is useful to make drawing faster."

	| drawAsRect |
	drawAsRect _ false.  "rectangles are faster to draw"
	drawAsRect
		ifTrue: [aCanvas fillRectangle: self bounds color: color]
		ifFalse: [super drawOn: aCanvas].