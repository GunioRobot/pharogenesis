primitiveObjectPointsTo
	| rcvr thang lastField |
	thang _ self popStack.
	rcvr _ self popStack.
	(self isIntegerObject: rcvr) ifTrue: [^ self pushBool: false].
	lastField _ self lastPointerOf: rcvr.
	BaseHeaderSize to: lastField by: 4 do:
		[:i | (self longAt: rcvr + i) = thang
			ifTrue: [^ self pushBool: true]].
	self pushBool: false.