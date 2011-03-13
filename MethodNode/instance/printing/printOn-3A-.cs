printOn: aStream 
	precedence = 1
		ifTrue: 
			[aStream nextPutAll: self selector]
		ifFalse: 
			[self selector keywords with: arguments do: 
				[:kwd :arg | 
				aStream nextPutAll: kwd; space.
				aStream withStyleFor: #methodArgument
					do: [aStream nextPutAll: arg key].
				aStream space]].
	comment == nil ifFalse: 
			[aStream crtab: 1.
			self printCommentOn: aStream indent: 1].
	temporaries size > 0 ifTrue: 
			[aStream crtab: 1.
			aStream nextPutAll: '|'.
			aStream withStyleFor: #temporaryVariable
				do: [temporaries do: 
						[:temp | aStream space; nextPutAll: temp key]].
				aStream nextPutAll: ' |'].
	properties ifNotNil: [ 
		properties pragmas do: [ :each |
			"Don't decompile basic primitives that return self, i-vars, etc."
			each keyword = #primitive:
				ifFalse: [ aStream crtab: 1. each printOn: aStream ]
				ifTrue: [
					( (each argumentAt: 1) isNumber and: [(each argumentAt: 1) between: 255 and: 519])
						ifFalse: [ aStream crtab: 1. self printPrimitiveOn: aStream ] ] ] ].
	aStream crtab: 1.
	^ block printStatementsOn: aStream indent: 0