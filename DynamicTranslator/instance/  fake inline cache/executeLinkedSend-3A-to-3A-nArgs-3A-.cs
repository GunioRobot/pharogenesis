executeLinkedSend: tMeth to: rcvr nArgs: nArgs
	"Need to set up messageSelector for the benefit of primitivePerform."

	| primIdx |
	self inline: true.

	newReceiver _ rcvr.	"XXX this is not necessary XXX"
	messageSelector _ self fetchPointer: MethodSelectorIndex ofObject: tMeth.
	argumentCount _ nArgs.
	primIdx _ self fetchPointer: MethodPrimIndex ofObject: tMeth.
	self assertIsIntegerObject: primIdx.
	primitiveIndex _ self integerValueOf: primIdx.
	newMethod _ self fetchPointer: MethodMethodIndex ofObject: tMeth.
	self assertIsCompiledMethod: newMethod.
	newTranslatedMethod _ tMeth.
	self externalizeIPandSP.
	self executeNewMethod.
	self internalizeIPandSP.