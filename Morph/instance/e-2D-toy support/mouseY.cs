mouseY
	"Return the vertical position of the mouse with respect to my reference playfield"

	| aPlayfield aY w |
	aY _ self primaryHand lastEvent targetPoint y.
	w _ self world.
	w ifNil: [^ bounds top].
	aPlayfield _ self referencePlayfield.

	^ aPlayfield == nil
		ifTrue: [w bottom - aY]
		ifFalse: [aPlayfield bottom - aY]