primitiveEquivalent
	| thisObject otherObject |
	otherObject _ self popStack.
	thisObject _ self popStack.
	self pushBool: thisObject = otherObject