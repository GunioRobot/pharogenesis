stackListIndex: index 
	stackListIndex := index.
	selectedContext := nil.
	(stackList notNil
			and: [index > 0])
		ifTrue: [selectedContext := stackList
						at: index
						ifAbsent: []].
	sourceMap := nil.
	selectedClass := nil.
	selectedSelector := nil.
	methodText := nil.
	self changed: #stackListIndex.
	self changed: #selectedMethod