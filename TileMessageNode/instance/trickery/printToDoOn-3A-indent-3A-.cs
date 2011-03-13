printToDoOn: aMorph indent: level

	| limitNode |
	
	limitNode _ (arguments last == nil or: [(arguments last isMemberOf: AssignmentNode) not])
		ifTrue: [arguments first]
		ifFalse: [arguments last value].
	(selector key = #to:by:do:
			and: [(arguments at: 2) isConstantNumber
				and: [(arguments at: 2) key = 1]])
		ifTrue: [self printKeywords: #to:do:
					arguments: (Array with: limitNode with: (arguments at: 3))
					on: aMorph indent: level]
		ifFalse: [self printKeywords: selector key
					arguments: (Array with: limitNode) , arguments allButFirst
					on: aMorph indent: level]