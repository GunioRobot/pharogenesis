y: aNumber 
	"Set my vertical position relative to the cartesian origin of the playfield or the world. Note that larger y values are closer to the top of the screen."

	| w offset newY aPlayfield |
	w := self world.
	w ifNil: [^self position: bounds left @ aNumber].
	aPlayfield := self referencePlayfield.
	offset := self top - self referencePosition y.
	newY := aPlayfield isNil
				ifTrue: [w bottom - aNumber + offset]
				ifFalse: [aPlayfield cartesianOrigin y - aNumber + offset].
	self position: bounds left @ newY