follow: anObject from: parentObject
	anObject == goal
		ifTrue: 
			[parents at: anObject put: parentObject.
			^ true].
	anObject isLiteral ifTrue: [^ false].
	anObject class isPointers ifFalse: [^ false].
	anObject class isWeak ifTrue: [^ false].
	(parents includesKey: anObject)
		ifTrue: [^ false].
	parents at: anObject put: parentObject.
	toDoNext add: anObject.
	^ false