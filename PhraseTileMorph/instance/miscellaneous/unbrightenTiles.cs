unbrightenTiles
	brightenedOnEnter ifFalse: [^ self].
	brightenedOnEnter _ false.
	self allMorphsDo: [:m |
		(m isKindOf: TileMorph) ifTrue:
			[m color: (ScriptingSystem unbrightColorFor: m color)]]
