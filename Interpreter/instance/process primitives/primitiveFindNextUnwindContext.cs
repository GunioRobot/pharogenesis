primitiveFindNextUnwindContext
	"Primitive. Search up the context stack for the next method context marked for unwind handling from the receiver up to but not including the argument. Return nil if none found."
	| thisCntx nilOop aContext unwindMarked |
	aContext _ self popStack.
	thisCntx _ self fetchPointer: SenderIndex ofObject: self popStack.
	nilOop _ nilObj.

	[(thisCntx = aContext) or: [thisCntx = nilOop]] whileFalse: [
		unwindMarked _ self isUnwindMarked: thisCntx.
		unwindMarked ifTrue:[
			self push: thisCntx.
			^nil].
		thisCntx _ self fetchPointer: SenderIndex ofObject: thisCntx].

	^self push: nilOop