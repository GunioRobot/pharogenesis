primitivePerformAt: lookupClass
	"Common routine used by perform:withArgs: and perform:withArgs:inSuperclass:"

	"NOTE:  The case of doesNotUnderstand: is not a failure to perform.
	The only failures are arg types and consistency of argumentCount."

	| performSelector argumentArray arraySize index cntxSize performMethod performArgCount |
	argumentArray _ self stackTop.
	(self isArray: argumentArray) ifFalse:[^self primitiveFail].

	successFlag ifTrue:
		["Check for enough space in thisContext to push all args"
		arraySize _ self fetchWordLengthOf: argumentArray.
		cntxSize _ self fetchWordLengthOf: activeContext.
		self success: (self stackPointerIndex + arraySize) < cntxSize].
	successFlag ifFalse: [^nil].

	performSelector _ messageSelector.
	performMethod _ newMethod.
	performArgCount _ argumentCount.
	"pop the arg array and the selector, then push the args out of the array, as if they were on the stack"
	self popStack.
	messageSelector _ self popStack.

	"Copy the arguments to the stack, and execute"
	index _ 1.
	[index <= arraySize]
		whileTrue:
		[self push: (self fetchPointer: index - 1 ofObject: argumentArray).
		index _ index + 1].
	argumentCount _ arraySize.

	self findNewMethodInClass: lookupClass.

	"Only test CompiledMethods for argument count - any other objects playacting as CMs will have to take their chances"
	(self isCompiledMethod: newMethod)
		ifTrue: [self success: (self argumentCountOf: newMethod) = argumentCount].

	successFlag
		ifTrue: [self executeNewMethodFromCache.  "Recursive xeq affects successFlag"
				successFlag _ true]
		ifFalse: ["Restore the state by popping all those array entries and pushing back the selector and array, and fail"
				self pop: argumentCount.
				self push: messageSelector.
				self push: argumentArray.
				messageSelector _ performSelector.
				newMethod _ performMethod.
				argumentCount _ performArgCount]
