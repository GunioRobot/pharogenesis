add: newObject 
	| index |
	newObject == nil ifTrue: [self halt: 'Sets cannot meaningfully contain nil as an element'].
	index _ self findElementOrNil: newObject.
	(array at: index) == nil ifTrue:
		[self atNewIndex: index put: newObject].
	^ newObject