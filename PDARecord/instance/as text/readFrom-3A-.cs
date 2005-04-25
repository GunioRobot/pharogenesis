readFrom: aText
	| buffer tokenStream fieldName token |
	tokenStream _ ReadStream on: (Scanner new scanTokens: aText asString).
	buffer _ WriteStream on: (String new: 500).
	fieldName _ nil.
	self sharedFieldsWithBaseDo:
		[:fields :instVarBase |  
		[tokenStream atEnd] whileFalse:
			[token _ tokenStream next.
			((token isSymbol) and: [token endsWith: ':'])
				ifTrue: [fieldName ifNotNil:
							[self readField: fieldName fromString: buffer contents
								fields: fields base: instVarBase].
						buffer reset.  fieldName _ token allButLast]
				ifFalse: [(token isSymbol)
							ifTrue: [buffer nextPutAll: token; space]
							ifFalse: [buffer print: token; space]]].
		self readField: fieldName fromString: buffer contents
			fields: fields base: instVarBase]