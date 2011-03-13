y
	"Return my vertical position relative to the bottom of the playfield or the world. Note that larger y values are closer to the top of the screen."

	| w aPlayfield |
	w _ self world.
	w ifNil: [^ bounds top].
	aPlayfield _ self referencePlayfield.

	^ aPlayfield == nil
		ifTrue: [w bottom - self referencePosition y]
		ifFalse: [aPlayfield bottom - self referencePosition y]