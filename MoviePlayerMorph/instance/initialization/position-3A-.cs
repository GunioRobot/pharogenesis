position: newPos
	super position: newPos.
	(currentPage ~~ nil and: [currentPage left odd])
		ifTrue: ["crude word alignment for depth = 16"
				super position: newPos + (1@0)]