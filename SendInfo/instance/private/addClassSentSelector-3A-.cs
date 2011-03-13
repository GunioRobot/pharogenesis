addClassSentSelector: aSymbol
	classSentSelectors ifNil: [classSentSelectors _ IdentitySet new].
	classSentSelectors add: aSymbol.