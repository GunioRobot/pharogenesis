primitivePerform
	| performSelector newReceiver selectorIndex |
	performSelector _ messageSelector.
	messageSelector _ self stackValue: argumentCount - 1.
	newReceiver _ self stackValue: argumentCount.
	"NOTE: the following lookup may fail and be converted to #doesNotUnderstand:,
		so we must adjust argument count now, so that would work."
	argumentCount _ argumentCount - 1.
	self lookupMethodInClass: (self fetchClassOf: newReceiver).
	self success: (self argumentCountOf: newMethod) = argumentCount.
	successFlag
		ifTrue: [selectorIndex _ self stackPointerIndex - argumentCount.
				self transfer: argumentCount
					fromIndex: selectorIndex + 1
					ofObject: activeContext
					toIndex: selectorIndex
					ofObject: activeContext.
				self pop: 1.
				self executeNewMethod.  "Recursive xeq affects successFlag"
				successFlag _ true]
		ifFalse: [argumentCount _ argumentCount + 1.
				messageSelector _ performSelector]