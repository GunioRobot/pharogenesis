y
	"Return my vertical position relative to the cartesian origin of the playfield or the world. Note that larger y values are closer to the top of the screen."

	| w aPlayfield |
	w := self world.
	w ifNil: [^bounds top].
	aPlayfield := self referencePlayfield.
	^aPlayfield isNil 
		ifTrue: [w cartesianOrigin y - self referencePosition y]
		ifFalse: [aPlayfield cartesianOrigin y - self referencePosition y]