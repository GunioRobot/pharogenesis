= anObject

	^ self == anObject
		ifTrue: [true]
		ifFalse: [anObject isHeap
			ifTrue: [sortBlock = anObject sortBlock and: [super = anObject]]
			ifFalse: [super = anObject]]