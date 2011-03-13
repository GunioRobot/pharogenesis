addSelfSentSelector: aSymbol
	selfSentSelectors ifNil: [selfSentSelectors _ IdentitySet new].
	selfSentSelectors add: aSymbol.