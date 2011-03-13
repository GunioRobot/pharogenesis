addSelfSentSelector: aSymbol
	selfSentSelectors ifNil: [selfSentSelectors := IdentitySet new].
	selfSentSelectors add: aSymbol.