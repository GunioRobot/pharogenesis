primitivePerform
	| performSelector newReceiver selectorIndex lookupClass performMethod |
	performSelector _ messageSelector.
	performMethod _ newMethod.
	messageSelector _ self stackValue: argumentCount - 1.
	newReceiver _ self stackValue: argumentCount.

	"NOTE: the following lookup may fail and be converted to #doesNotUnderstand:, so we must adjust argumentCount and slide args now, so that would work."

	"Slide arguments down over selector"
	argumentCount _ argumentCount - 1.
	selectorIndex _ self stackPointerIndex - argumentCount.
	self
		transfer: argumentCount
		fromIndex: selectorIndex + 1
		ofObject: activeContext
		toIndex: selectorIndex
		ofObject: activeContext.
	self pop: 1.
	lookupClass _ self fetchClassOf: newReceiver.
	self findNewMethodInClass: lookupClass.

	"Only test CompiledMethods for argument count - other objects will have to take their chances"
	(self isCompiledMethod: newMethod)
		ifTrue: [self success: (self argumentCountOf: newMethod) = argumentCount].

	successFlag
		ifTrue: [self executeNewMethodFromCache.
			"Recursive xeq affects successFlag"
			successFlag _ true]
		ifFalse: ["Slide the args back up (sigh) and re-insert the 
			selector. "
			1 to: argumentCount do: [:i | self
						storePointer: argumentCount - i + 1 + selectorIndex
						ofObject: activeContext
						withValue: (self fetchPointer: argumentCount - i + selectorIndex ofObject: activeContext)].
			self unPop: 1.
			self storePointer: selectorIndex
				ofObject: activeContext
				withValue: messageSelector.
			argumentCount _ argumentCount + 1.
			newMethod _ performMethod.
			messageSelector _ performSelector]