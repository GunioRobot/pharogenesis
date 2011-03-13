with: arg1 with: arg2 executeMethod: compiledMethod
	"Execute compiledMethod against the receiver and arg1 & arg2"

	"<primitive: 189>" "uncomment once prim 189 is in VM"
	^ self withArgs: {arg1. arg2} executeMethod: compiledMethod