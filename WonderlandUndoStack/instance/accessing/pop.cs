pop
	"Takes the top undo action off the stack."

	| lastItem |

	(theStack isEmpty) ifTrue: [lastItem _ nil]
					   ifFalse: [lastItem _ theStack removeLast].

	^ lastItem.
