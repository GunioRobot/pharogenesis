generateAsIfVarPut: aNode on: aStream indent: anInteger

	| cName fName class index |
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
	aStream 
		nextPutAll: 'interpreterProxy->storePointerofObjectwithValue(';
		nextPutAll: (index - 1) asString;
		nextPutAll: ','.
	self emitCExpression: aNode receiver on: aStream.
	aStream nextPutAll: ','.
	self emitCExpression: aNode args third on: aStream.
	aStream nextPutAll: ')'.