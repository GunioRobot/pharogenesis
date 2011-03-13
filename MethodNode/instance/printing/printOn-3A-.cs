printOn: aStream
	| s args |
	precedence = 1
		ifTrue: 
			[aStream nextPutAll: self selector]
		ifFalse: 
			[args _ ReadStream on: arguments.
			self selector keywords with: arguments do: 
				[:s :arg | 
				aStream nextPutAll: s; space; nextPutAll: arg key; space]].
	aStream cr.
	comment == nil ifFalse: 
			[self printCommentOn: aStream indent: 0.
			aStream cr].
	temporaries isEmpty 
		ifTrue: [comment == nil ifFalse: [aStream cr]]
		ifFalse: [aStream tab; nextPutAll: '| '.
				temporaries do: 
					[:temp | aStream nextPutAll: temp key; space].
				aStream nextPut: $|; cr].
	(primitive between: 1 and: 255) ifTrue:
			[self printPrimitiveOn: aStream.
			aStream cr].
	^ block printStatementsOn: aStream indent: 0