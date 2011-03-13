size
	^self inject: 0 into: [ :count :dep | dep ifNil: [ count ] ifNotNil: [ count + 1 ]]