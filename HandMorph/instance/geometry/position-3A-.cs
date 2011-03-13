position: aPoint
	"Overridden to align submorph origins to the grid if gridding is on."

	temporaryCursorOffset ifNil: [temporaryCursorOffset _ 0@0].
	gridOn
		ifTrue: [^ super position: (aPoint grid: grid) - temporaryCursorOffset]
		ifFalse: [^ super position: aPoint - temporaryCursorOffset].
