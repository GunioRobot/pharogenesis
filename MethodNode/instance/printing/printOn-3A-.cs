printOn: aStream 
	| args |
	precedence = 1
		ifTrue: 
			[aStream nextPutAll: self selector]
		ifFalse: 
			[args _ ReadStream on: arguments.
			self selector keywords do: 
				[:s | 
				aStream nextPutAll: s; space.
				aStream withAttribute: (TextColor color: Color green)
					do: [aStream nextPutAll: args next key].
				aStream space]].
	comment == nil ifFalse: 
			[aStream crtab: 1.
			self printCommentOn: aStream indent: 1].
	temporaries size > 0 ifTrue: 
			[aStream crtab: 1.
			aStream nextPutAll: '| '.
			aStream withAttribute: (TextColor color: Color green)
				do: [temporaries do: 
					[:temp | 
					aStream nextPutAll: temp key.
					aStream space]].
			aStream nextPut: $|].
	primitive > 0 ifTrue:
			[primitive < 256 ifTrue:  " Dont decompile <prim> for, eg, ^ self "
				[aStream crtab: 1.
				self printPrimitiveOn: aStream]].
	aStream crtab: 1.
	^block printStatementsOn: aStream indent: 0