constantTile: anObject

	(anObject isKindOf: Color) ifTrue:
		[^ ColorTileMorph new typeColor: (ScriptingSystem colorForType: #color)].

	^ anObject newTileMorphRepresentative
		typeColor: (ScriptingSystem colorForType: (self typeForConstant: anObject))