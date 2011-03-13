follow: anObject from: parentObject
	anObject == goal
		ifTrue: 
			[parents at: anObject put: parentObject.
			^ true].
	anObject isLiteral ifTrue: [^ false].
	"Remove this after switching to new CompiledMethod format --bf 2/12/2006"
	(anObject class isPointers or: [anObject isCompiledMethod]) ifFalse: [^ false].
	anObject class isWeak ifTrue: [^ false].
	(parents includesKey: anObject)
		ifTrue: [^ false].
	parents at: anObject put: parentObject.
	toDoNext add: anObject.
	^ false