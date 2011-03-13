addClassSentSelector: aSymbol
	classSentSelectors ifNil: [classSentSelectors := IdentitySet new].
	classSentSelectors add: aSymbol.