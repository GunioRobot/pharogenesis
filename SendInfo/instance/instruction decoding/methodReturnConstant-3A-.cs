methodReturnConstant: aConstant
	"Simulate the action of a 'return receiver' bytecode. This corresponds to 
	the source expression '^aConstant'."

	self push: aConstant.
	self emptyStack