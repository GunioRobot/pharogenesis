storeLiteral: aCodeLiteral on: aStream
	"Store aCodeLiteral on aStream, changing an Association to ##GlobalName
	 or ###MetaclassSoleInstanceName format if appropriate"
	| key value |
	(aCodeLiteral isMemberOf: Association)
		ifFalse:
			[aCodeLiteral storeOn: aStream.
			 ^self].
	key _ aCodeLiteral key.
	(key isNil and: [(value _ aCodeLiteral value) isMemberOf: Metaclass])
		ifTrue:
			[aStream nextPutAll: '###'; nextPutAll: value soleInstance name.
			 ^self].
	((key isMemberOf: Symbol) and: [self scopeHas: key ifTrue: [:ignore]])
		ifTrue:
			[aStream nextPutAll: '##'; nextPutAll: key.
			 ^self].
	aCodeLiteral storeOn: aStream