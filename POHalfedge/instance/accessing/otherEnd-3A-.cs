otherEnd: aVertex
	self origin = aVertex ifTrue: [^ self destination]
ifFalse: [^ self origin]