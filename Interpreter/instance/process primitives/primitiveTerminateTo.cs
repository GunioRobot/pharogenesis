primitiveTerminateTo
	"Primitive. Terminate up the context stack from the receiver up to but not including the argument, if previousContext is on my Context stack. Make previousContext my sender. This prim has to shadow the code in ContextPart>terminateTo: to be correct"
	| thisCntx currentCntx aContext nextCntx nilOop |
	aContext _ self popStack.
	thisCntx _ self popStack.

	"make sure that aContext is in my chain"
	(self context: thisCntx hasSender: aContext) ifTrue:[
		nilOop _ nilObj.
		currentCntx _ self fetchPointer: SenderIndex ofObject: thisCntx.
		[currentCntx = aContext] whileFalse: [
			nextCntx _ self fetchPointer: SenderIndex ofObject: currentCntx.
			self storePointer: SenderIndex ofObject: currentCntx withValue: nilOop.
			self storePointer: InstructionPointerIndex ofObject: currentCntx withValue: nilOop.
			currentCntx _ nextCntx]].

	self storePointer: SenderIndex ofObject: thisCntx withValue: aContext.
	^self push: thisCntx