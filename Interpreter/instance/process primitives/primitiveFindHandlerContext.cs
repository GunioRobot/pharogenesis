primitiveFindHandlerContext
	"Primitive. Search up the context stack for the next method context marked for exception handling starting at the receiver. Return nil if none found"
	| thisCntx nilOop |
	thisCntx _ self popStack.
	nilOop _ nilObj.

	[(self isHandlerMarked: thisCntx) ifTrue:[
			self push: thisCntx.
			^nil].
		thisCntx _ self fetchPointer: SenderIndex ofObject: thisCntx.
		thisCntx = nilOop] whileFalse.

	^self push: nilObj