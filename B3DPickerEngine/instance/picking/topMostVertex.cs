topMostVertex
	"Return the top most primitive vertex of all picked objects.
	Note: Except from the z value the vertex is *not* normalized yet 
		(e.g., there was no division by w)"
	^pickList isEmpty
		ifTrue:[nil]
		ifFalse:[pickList first value]