labelForFilter: aFilterSymbol 
	^(self filterSpecs detect: [:fs | fs second = aFilterSymbol]) first