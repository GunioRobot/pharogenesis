closeTypeIn
	"See comment in openTypeIn.  It is important to call closeTypeIn before executing
	 any non-typing key, making a new selection, etc.  It is called automatically for
	 menu commands.
	 Typing commands can call 'closeTypeIn: aCharacterStream' instead of this to
	 save typeahead.  Undoer & Redoer: undoAndReselect:redoAndReselect:."

	| begin stop |
	beginTypeInBlock == nil ifFalse:
		[(UndoMessage sends: #noUndoer) ifTrue: "should always be true, but just in case..."
			[begin := self startOfTyping.
			stop := self stopIndex.
			self undoer: #undoAndReselect:redoAndReselect:
				with: (begin + UndoMessage argument to: begin + UndoSelection size - 1)
				with: (stop to: stop - 1).
			UndoInterval := begin to: stop - 1].
		beginTypeInBlock := nil]