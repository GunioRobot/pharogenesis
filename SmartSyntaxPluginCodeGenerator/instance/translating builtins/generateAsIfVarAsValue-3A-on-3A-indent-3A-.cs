generateAsIfVarAsValue: aNode on: aStream indent: anInteger

	| cName fName class index fetchNode |
	cName _ String streamContents: 
		[:scStr | self emitCExpression: aNode args first on: scStr].
	class _ Smalltalk 
		at: (cName asSymbol) 
		ifAbsent: [nil].
	(class isNil not and: [class isBehavior]) ifFalse: 
		[^self error: 'first arg must identify class'].
	fName _ aNode args second value.
	index _ class allInstVarNames
		indexOf: fName
		ifAbsent: [^self error: 'second arg must be instVar'].
	fetchNode _ TSendNode new
		setSelector: #fetchPointer:ofObject:
		receiver: (TVariableNode new setName: 'interpreterProxy')
		arguments: (Array
			with: (TConstantNode new setValue: index - 1)
			with: aNode receiver).
	cName _ aNode args third nameOrValue.
	class _ Smalltalk 
		at: (cName asSymbol) 
		ifAbsent: [nil].
	(class isNil not and: [class isBehavior]) ifFalse: 
		[^self error: 'third arg must identify class'].
	class ccg: self generateCoerceToValueFrom: fetchNode on: aStream
