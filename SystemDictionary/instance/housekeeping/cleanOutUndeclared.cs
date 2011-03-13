cleanOutUndeclared  "Smalltalk cleanOutUndeclared"
	Undeclared keys do:
	[:key | (Smalltalk allCallsOn: (Undeclared associationAt: key)) isEmpty
				ifTrue: [Undeclared removeKey: key]].
