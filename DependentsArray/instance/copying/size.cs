size
	^self inject: 0 into: [ :count :dep | dep ifNotNil: [ count _ count + 1 ]]