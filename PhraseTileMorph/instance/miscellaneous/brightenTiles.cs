brightenTiles
	brightenedOnEnter _ true.
	self allMorphsDo: [:m |
		(m isKindOf: TileMorph) ifTrue:
			[m color: (ScriptingSystem brightColorFor: m color)]]
