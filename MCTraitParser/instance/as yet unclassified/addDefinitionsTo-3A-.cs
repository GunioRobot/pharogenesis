addDefinitionsTo: aCollection
	| tokens  definition traitCompositionString |
	tokens := Scanner new scanTokens: source.
	traitCompositionString := (source readStream
		match: 'uses:';
		upToAll: 'category:') withBlanksTrimmed.
	definition := MCTraitDefinition
		name: (tokens at: 3) 
		traitComposition: traitCompositionString
		category:  tokens last
		comment:  ''  
		commentStamp:   ''.
	aCollection add: definition.