displayBufferSelection
	"where the selection should be in the display buffer.  It should be where the cursor is"
	| pos |
	pos _ cursorY * 81 + cursorX - 82.
	^pos+1 to: pos