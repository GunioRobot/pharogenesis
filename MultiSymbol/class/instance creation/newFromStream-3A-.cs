newFromStream: stream 

	| length multiString |
	self isPointers | self isWords not
		ifTrue: [^ super newFromStream: stream].
	stream next = 128
		ifTrue: [^ self error: 'not implemented'].
	stream skip: -1.
	length _ stream nextInt32.
	multiString _ stream
				nextWordsInto: (MultiString basicNew: length).
	^ multiString asSymbol
