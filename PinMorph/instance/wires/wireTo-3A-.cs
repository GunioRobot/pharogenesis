wireTo: otherPin 
	"Note must return true or false indicating success"

	(otherPin isNil or: [otherPin == self]) ifTrue: [^false].
	self hasVariable 
		ifTrue: 
			[otherPin hasVariable 
				ifTrue: [self mergeVariableWith: otherPin]
				ifFalse: [otherPin shareVariableOf: self]]
		ifFalse: 
			[otherPin hasVariable 
				ifTrue: [self shareVariableOf: otherPin]
				ifFalse: 
					[self addModelVariable.
					otherPin shareVariableOf: self]].
	component model changed: pinSpec modelReadSelector.
	^true