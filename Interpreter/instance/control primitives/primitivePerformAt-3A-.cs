primitivePerformAt: lookupClass
	"Common routine used by perform:withArgs: and perform:withArgs:inSuperclass:"

	"NOTE:  The case of doesNotUnderstand: is not a failure to perform.
	The only failures are arg types and consistency of argumentCount."

	| performSelector argumentArray arraySize index cntxSize performMethod performArgCount |
	argumentArray _ self popStack.
	self assertClassOf: argumentArray is: (self splObj: ClassArray).
	successFlag ifTrue:
		["Check for enough space to push all args"
		arraySize _ self fetchWordLengthOf: argumentArray.
		cntxSize _ self fetchWordLengthOf: activeContext.
		self success: (self stackPointerIndex + arraySize) < cntxSize].
	successFlag ifFalse: [^ self unPop: 1].

	performSelector _ messageSelector.
	performMethod _ newMethod.
	performArgCount _ argumentCount.
	messageSelector _ self popStack.

	"Copy the arguments to the stack, and execute"
	index _ 1.
	[index <= arraySize]
		whileTrue:
		[self push: (self fetchPointer: index - 1 ofObject: argumentArray).
		index _ index + 1].
	argumentCount _ arraySize.
	self findNewMethodInClass: lookupClass.
	self success: (self argumentCountOf: newMethod) = argumentCount.
	successFlag
		ifTrue: [self executeNewMethod.  "Recursive xeq affects successFlag"
				successFlag _ true]
		ifFalse: ["Restore the state and fail"
				self pop: argumentCount.
				self push: messageSelector.
				self push: argumentArray.
				messageSelector _ performSelector.
				newMethod _ performMethod.
				argumentCount _ performArgCount]
