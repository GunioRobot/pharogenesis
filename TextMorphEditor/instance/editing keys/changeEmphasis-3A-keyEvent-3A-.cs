changeEmphasis: aStream keyEvent: keyEvent
	"Change the emphasis of the current selection."
	| retval |
	retval := super changeEmphasis: aStream keyEvent: keyEvent.
	paragraph composeAll.
	self recomputeInterval.
	morph updateFromParagraph.
	^retval