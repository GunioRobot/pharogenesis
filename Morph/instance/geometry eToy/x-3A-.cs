x: aNumber 
	"Set my horizontal position relative to the cartesian origin of the playfield or the world."

	| offset aPlayfield newX |
	aPlayfield := self referencePlayfield.
	offset := self left - self referencePosition x.
	newX := aPlayfield isNil
				ifTrue: [aNumber + offset]
				ifFalse: [aPlayfield cartesianOrigin x + aNumber + offset].
	self position: newX @ bounds top