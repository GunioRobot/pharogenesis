printOn: aStream 

	precedence = 1
		ifTrue: 
			[aStream nextPutAll: self selector]
		ifFalse: 
			[self selector keywords with: arguments do: 
				[:kwd :arg | 
				aStream dialect = #SQ00
					ifTrue: [(kwd endsWith: ':')
							ifTrue: [aStream withStyleFor: #methodSelector
									do: [aStream nextPutAll: kwd allButLast].
									aStream nextPutAll: ' (']
							ifFalse: [aStream withStyleFor: #methodSelector
									do: [aStream nextPutAll: kwd].
									aStream space]]
					ifFalse: [aStream nextPutAll: kwd; space].
				aStream withStyleFor: #methodArgument
					do: [aStream nextPutAll: arg key].
				(aStream dialect = #SQ00 and: [kwd endsWith: ':'])
					ifTrue: [aStream nextPutAll: ') ']
					ifFalse: [aStream space]]].
	comment == nil ifFalse: 
			[aStream crtab: 1.
			self printCommentOn: aStream indent: 1].
	temporaries size > 0 ifTrue: 
			[aStream crtab: 1.
			aStream dialect = #SQ00
				ifTrue: [aStream withStyleFor: #setOrReturn do: [aStream nextPutAll: 'Use']]
				ifFalse: [aStream nextPutAll: '|'].
			aStream withStyleFor: #temporaryVariable
				do: [temporaries do: 
						[:temp | aStream space; nextPutAll: temp key]].
			aStream dialect = #SQ00
				ifTrue: [aStream nextPutAll: '.']
				ifFalse: [aStream nextPutAll: ' |']].
	primitive > 0 ifTrue:
			[(primitive between: 255 and: 519) ifFalse:  " Dont decompile <prim> for, eg, ^ self "
				[aStream crtab: 1.
				self printPrimitiveOn: aStream]].
	aStream crtab: 1.
	^ block printStatementsOn: aStream indent: 0