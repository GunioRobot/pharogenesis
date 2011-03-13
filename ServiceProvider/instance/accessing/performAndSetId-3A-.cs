performAndSetId: aSymbol 
	| service |
	service := self perform: aSymbol.
	service id: aSymbol.
	^service