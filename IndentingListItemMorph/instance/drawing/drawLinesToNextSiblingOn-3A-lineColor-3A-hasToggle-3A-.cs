drawLinesToNextSiblingOn: aCanvas lineColor: lineColor hasToggle: hasToggle
	| myBounds nextSibBounds vLineX myCenter vLineTop vLineBottom |
	myBounds := self toggleBounds.
	nextSibBounds := self nextSibling toggleBounds.
	myCenter := myBounds center.
	vLineX := myCenter x - 1.
	hasToggle
		ifTrue: [vLineTop := myCenter y + 5]
		ifFalse: [vLineTop := myCenter y].
	self nextSibling hasToggle
		ifTrue: [vLineBottom := nextSibBounds top + 2 ]
		ifFalse: [vLineBottom :=  nextSibBounds center y ].
	"Draw line from me to next sibling"
	aCanvas
		line: vLineX @ vLineTop
		to: vLineX @ vLineBottom
		width: 1
		color: lineColor