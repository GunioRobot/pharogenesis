position: aPoint
	"Overridden to align submorph origins to the grid if gridding is on."

	gridOn
		ifTrue: [^ super position: (aPoint grid: grid)]
		ifFalse: [^ super position: aPoint].
