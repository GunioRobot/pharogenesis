drawLinesToFirstChildOn: aCanvas lineColor: lineColor 
	"Draw line from me to next sibling"

	| vLineX vLineTop vLineBottom childBounds childCenter |
	childBounds := self firstChild toggleBounds.
	childCenter := childBounds center.
	vLineX := childCenter x - 1.
	vLineTop := bounds bottom.
	self firstChild hasToggle
		ifTrue: [vLineBottom := childCenter y - 7]
		ifFalse: [vLineBottom := childCenter y].
	aCanvas
		line: vLineX @ vLineTop
		to: vLineX @ vLineBottom
		width: 1
		color: lineColor