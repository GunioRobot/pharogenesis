possiblyWrapCursor
	"if the cursor has gone past the right margin, then wrap"

	cursorX > 80 ifTrue: [
		cursorX _ 1.
		cursorY _ cursorY + 1.
		cursorY > 25 ifTrue: [
			cursorY _ 25.
			self scrollScreenBack: 1 ].
	].
