primitivePerformWithArgs
	| thisReceiver performSelector argumentArray arraySize index cntxSize |
	argumentArray _ self popStack.
	arraySize _ self fetchWordLengthOf: argumentArray.
	cntxSize _ self fetchWordLengthOf: activeContext.
	self success: (self stackPointerIndex + arraySize) < cntxSize.
	self assertClassOf: argumentArray is: (self splObj: ClassArray).
	successFlag
		ifTrue: [performSelector _ messageSelector.
				messageSelector _ self popStack.
				thisReceiver _ self stackTop.
				argumentCount _ arraySize.
				index _ 1.
				[index <= argumentCount]
					whileTrue:
					[self push: (self fetchPointer: index - 1 ofObject: argumentArray).
					index _ index + 1].
				self lookupMethodInClass: (self fetchClassOf: thisReceiver).
				self success: (self argumentCountOf: newMethod) = argumentCount.
				successFlag
					ifTrue: [self executeNewMethod.  "Recursive xeq affects successFlag"
							successFlag _ true]
					ifFalse: [self pop: argumentCount.
							self push: messageSelector.
							self push: argumentArray.
							argumentCount _ 2.
							messageSelector _ performSelector]]
	ifFalse: [self unPop: 1]