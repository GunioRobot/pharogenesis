primitiveEquivalent
"is the receiver the same object as the argument?"
	| thisObject otherObject |
	otherObject _ self popStack.
	thisObject _ self popStack.
	self pushBool: thisObject = otherObject