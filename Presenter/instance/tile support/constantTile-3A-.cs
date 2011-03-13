constantTile: anObject

	(anObject isKindOf: Color) ifTrue:
		[^ ColorTileMorph new typeColor: (TilePadMorph colorForType: #color)].

	^ anObject newTileMorphRepresentative
		typeColor: (TilePadMorph colorForType: (self typeForConstant: anObject))