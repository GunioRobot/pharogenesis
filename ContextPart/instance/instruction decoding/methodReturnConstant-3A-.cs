methodReturnConstant: value 
	"Simulate the action of a 'return constant' bytecode whose value is the 
	argument, value. This corresponds to a source expression like '^0'."

	^self return: value to: self home sender