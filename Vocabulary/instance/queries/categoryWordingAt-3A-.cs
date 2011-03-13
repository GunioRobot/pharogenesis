categoryWordingAt: aSymbol
	"Answer the wording for the category at the given symbol"

	| result |
	result := self categoryAt: aSymbol.
	^result
		ifNotNil: [result wording]
		ifNil: [aSymbol]