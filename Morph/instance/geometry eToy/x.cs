x
	"Return my horizontal position relative to the cartesian origin of a relevant playfield"

	| aPlayfield |
	aPlayfield := self referencePlayfield.
	^aPlayfield isNil 
		ifTrue: [self referencePosition x]
		ifFalse: [self referencePosition x - aPlayfield cartesianOrigin x]