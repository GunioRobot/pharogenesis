testNewTileMorphRepresentative

	self assert: (false newTileMorphRepresentative isKindOf: TileMorph).
	self assert: (false newTileMorphRepresentative literal = false).
	self assert: (true newTileMorphRepresentative literal = true).