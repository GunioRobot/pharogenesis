mapPrimitiveVertex: aPrimitiveVertex
	"Map the given primitive vertex into 2D space."
	| pt |
	pt _ aPrimitiveVertex texCoordS @ aPrimitiveVertex texCoordT.
	^(self extent * pt) asIntegerPoint + self position.