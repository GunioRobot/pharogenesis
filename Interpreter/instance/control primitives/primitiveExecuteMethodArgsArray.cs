primitiveExecuteMethodArgsArray
	"receiver, argsArray, then method are on top of stack.  Execute method against receiver and args"

	| argCnt argumentArray |
	newMethod _ self popStack.
	primitiveIndex _ self primitiveIndexOf: newMethod.
	argCnt _ self argumentCountOf: newMethod.
	argumentArray _ self popStack.
	"If the argArray isnt actually an Array we have to unPop both the above"
	(self isArray: argumentArray) ifFalse:[self unPop: 2. ^self primitiveFail].
	successFlag ifTrue: [self success: (argCnt = (self fetchWordLengthOf: argumentArray))].
	successFlag
		ifTrue: [self transfer: argCnt from: argumentArray + BaseHeaderSize to: stackPointer + 4.
			self unPop: argCnt.
			argumentCount _ argCnt.
			self executeNewMethod]
		ifFalse: [self unPop: 2].
