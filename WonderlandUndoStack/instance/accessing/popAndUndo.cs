popAndUndo
	"Takes the top undo action off the stack and does it (undoing the original action)."

	| lastItem |

	(theStack isEmpty) ifTrue: [lastItem _ nil]
					   ifFalse: [lastItem _ (theStack removeLast) undoIt].

	^ lastItem.
