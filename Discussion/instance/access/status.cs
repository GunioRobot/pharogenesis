status
	| reply |
	reply _ WriteStream on: String new.
	reply nextPutAll: 'Number of notes: ', (notes size printString).
	notes size > 0
		ifTrue: [reply nextPutAll: '. Last note: ',(notes last timestamp).].
	^reply contents