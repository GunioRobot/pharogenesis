primitiveExecuteMethod
	"receiver, args, then method are on top of stack. Execute method against receiver and args"
	newMethod := self popStack.
	primitiveIndex := self primitiveIndexOf: newMethod.
	self success: argumentCount - 1 = (self argumentCountOf: newMethod).
	successFlag
		ifTrue: [argumentCount := argumentCount - 1.
			self executeNewMethod]
		ifFalse: [self unPop: 1]