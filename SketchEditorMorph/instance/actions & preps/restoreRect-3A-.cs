restoreRect: oldRect
	"Restore the given rectangular area of the painting Form from the undo buffer."

	formCanvas image: undoBuffer
		at: oldRect origin
		sourceRect: (oldRect translateBy: self topLeft negated)
		rule: Form over.
	self invalidRect: oldRect.
