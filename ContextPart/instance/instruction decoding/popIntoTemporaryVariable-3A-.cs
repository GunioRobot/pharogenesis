popIntoTemporaryVariable: offset 
	"Simulate the action of bytecode that removes the top of the stack and 
	stores it into one of my temporary variables."

	self contextForLocalVariables at: offset + 1 put: self pop