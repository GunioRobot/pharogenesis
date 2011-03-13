addSuperSentSelector: aSymbol
	superSentSelectors ifNil: [superSentSelectors := IdentitySet new].
	superSentSelectors add: aSymbol.