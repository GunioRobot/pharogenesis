addDefinitionsTo: aCollection
	| tokens  definition traitCompositionString |
	tokens := Scanner new scanTokens: source.
	traitCompositionString := (source readStream
		match: 'uses:';
		upToEnd) withBlanksTrimmed.
	definition := MCClassTraitDefinition
		baseTraitName: (tokens at: 1) 
		classTraitComposition: traitCompositionString.
	aCollection add: definition
