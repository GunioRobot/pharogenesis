primitiveInvokeObjectAsMethod
	"Primitive. 'Invoke' an object like a function, sending the special message 
		run: originalSelector with: arguments in: aReceiver.
	"
	| runSelector runReceiver runArgs newReceiver lookupClass |
	runArgs _ self instantiateClass: (self splObj: ClassArray) indexableSize: argumentCount.
	self beRootIfOld: runArgs. "do we really need this?"
	self transfer: argumentCount from: stackPointer - ((argumentCount - 1) * 4) to: runArgs + BaseHeaderSize.

	runSelector _ messageSelector.
	runReceiver _ self stackValue: argumentCount.
	self pop: argumentCount+1.

	"stack is clean here"

	newReceiver _ newMethod.
	messageSelector _ self splObj: SelectorRunWithIn.
	argumentCount _ 3.

	self push: newReceiver.
	self push: runSelector.
	self push: runArgs.
	self push: runReceiver.

	lookupClass _ self fetchClassOf: newReceiver.
	self findNewMethodInClass: lookupClass.
	self executeNewMethodFromCache.  "Recursive xeq affects successFlag"
	successFlag _ true.
