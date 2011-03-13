printToDoOn: aStream indent: level
	(selector key = #to:by:do:
			and: [(arguments at: 2) isConstantNumber
				and: [(arguments at: 2) key = 1]])
		ifTrue: [self printKeywords: #to:do:
					arguments: (Array with: arguments first with: arguments last)
					on: aStream indent: level]
		ifFalse: [self printKeywords: selector key
					arguments: arguments
					on: aStream indent: level]