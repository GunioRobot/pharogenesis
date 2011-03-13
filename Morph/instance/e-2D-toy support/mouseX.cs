mouseX
	"Return the horizontal position of the mouse with respect to my reference playfield"

	| aPlayfield anX |
	anX _ self primaryHand lastEvent targetPoint x.
	aPlayfield _ self referencePlayfield.
	^ aPlayfield == nil
		ifTrue: [anX]
		ifFalse: [anX - aPlayfield left]