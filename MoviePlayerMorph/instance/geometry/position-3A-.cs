position: newPos 
	super position: newPos.
	(currentPage notNil and: [currentPage left odd]) 
		ifTrue: 
			["crude word alignment for depth = 16"

			super position: newPos + (1 @ 0)]