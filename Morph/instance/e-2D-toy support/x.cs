x
	"Return my horizontal position relative to the left edge of a relevant playfield"

	| aPlayfield |
	aPlayfield _ self referencePlayfield.
	^ aPlayfield == nil
		ifTrue: [self referencePosition x]
		ifFalse: [self referencePosition x - aPlayfield left]