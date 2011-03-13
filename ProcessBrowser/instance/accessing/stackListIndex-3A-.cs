stackListIndex: index 
	stackListIndex _ index.
	selectedContext _ nil.
	(stackList notNil
			and: [index > 0])
		ifTrue: [selectedContext _ stackList
						at: index
						ifAbsent: []].
	sourceMap _ nil.
	selectedClass _ nil.
	selectedSelector _ nil.
	methodText _ nil.
	self changed: #stackListIndex.
	self changed: #selectedMethod