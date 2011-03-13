jump: distance if: aBooleanConstant 
	"Simulate the action of a 'conditional jump' bytecode whose offset is 
	distance, and whose condition is aBooleanConstant."

	| destination |
	distance < 0 ifTrue:[^ self].
	distance = 0 ifTrue:[self error: 'bad compiler!'].
	destination := self pc + distance.
	"remove the condition from the stack."
	self pop.
	savedStacks at: destination put: stack copy.
