categoryWordingAt: aSymbol
	"Answer the wording for the category at the given symbol"

	| result |
	result _ self categoryAt: aSymbol.
	^result
		ifNotNil: [result wording]
		ifNil: [aSymbol]