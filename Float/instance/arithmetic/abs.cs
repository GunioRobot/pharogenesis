abs
	self < 0.0
		ifTrue: [^ self negated]
		ifFalse: [^ self]