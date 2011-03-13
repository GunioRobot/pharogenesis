addSuperSentSelector: aSymbol
	superSentSelectors ifNil: [superSentSelectors _ IdentitySet new].
	superSentSelectors add: aSymbol.