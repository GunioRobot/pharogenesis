ccg: cg generateCoerceToOopFrom: aNode on: aStream

	self instSize > 0 ifTrue: 
		[self error: 'cannot auto-coerce arrays with named instance variables'].
	cg generateCoerceToObjectFromPtr: aNode on: aStream