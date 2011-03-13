brightenTiles

	brightenedOnEnter _ true.
	self allMorphsDo: [:m |
		(m isKindOf: TileMorph) ifTrue: [
			m color: (TilePadMorph brightColorFor: m color)]].
