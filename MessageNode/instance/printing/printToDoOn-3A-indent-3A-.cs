printToDoOn: aStream indent: level

	| limitNode |
	
	self printReceiver: receiver on: aStream indent: level.

	(arguments last == nil or: [(arguments last isMemberOf: AssignmentNode) not])
		ifTrue: [limitNode _ arguments first]
		ifFalse: [limitNode _ arguments last value].
	(selector key = #to:by:do:
			and: [(arguments at: 2) isConstantNumber
				and: [(arguments at: 2) key = 1]])
		ifTrue: [self printKeywords: #to:do:
					arguments: (Array with: limitNode with: (arguments at: 3))
					on: aStream indent: level prefix: true]
		ifFalse: [self printKeywords: selector key
					arguments: (Array with: limitNode) , arguments allButFirst
					on: aStream indent: level prefix: true]