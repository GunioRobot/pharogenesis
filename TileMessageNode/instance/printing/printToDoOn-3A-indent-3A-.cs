printToDoOn: aMorph indent: level 
	| limitNode |
	limitNode := (arguments last isNil 
				or: [(arguments last isMemberOf: AssignmentNode) not]) 
					ifTrue: [arguments first]
					ifFalse: [arguments last value].
	(selector key = #to:by:do: 
		and: [arguments second isConstantNumber and: [arguments second key = 1]]) 
			ifTrue: 
				[self 
					printKeywords: #to:do:
					arguments: (Array with: limitNode with: (arguments third))
					on: aMorph
					indent: level]
			ifFalse: 
				[self 
					printKeywords: selector key
					arguments: (Array with: limitNode) , arguments allButFirst
					on: aMorph
					indent: level]