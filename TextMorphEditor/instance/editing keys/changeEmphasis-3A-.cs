changeEmphasis: aStream
	"Change the emphasis of the current selection."
	| retval |
	retval := super changeEmphasis: aStream.
	paragraph composeAll.
	self recomputeInterval.
	morph updateFromParagraph.
	^retval