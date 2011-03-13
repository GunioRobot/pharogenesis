named: aSymbol uses: aTraitCompositionOrCollection category: aString
	| env |
	env _ self environment.
	^self
		named: aSymbol
		uses: aTraitCompositionOrCollection
		category: aString
		env: env