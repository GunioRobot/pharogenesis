intern: aStringOrSymbol 

	^(self lookup: aStringOrSymbol) ifNil:[
		| aClass aSymbol |
		aStringOrSymbol isSymbol ifTrue:[
			aSymbol _ aStringOrSymbol.
		] ifFalse:[
			aClass := aStringOrSymbol isOctetString ifTrue:[ByteSymbol] ifFalse:[WideSymbol].
			aSymbol := aClass new: aStringOrSymbol size.
			aSymbol string: aStringOrSymbol.
		].
		NewSymbols add: aSymbol.
		aSymbol].