closeTypeIn
	"See comment in openTypeIn.  It is important to call closeTypeIn before executing
	 any non-typing key, making a new selection, etc.  It is called automatically for
	 menu commands.
	 Typing commands can call 'closeTypeIn: aCharacterStream' instead of this to
	 save typeahead.  Undoer & Redoer: undoAndReselect:redoAndReselect:."

	| begin start stop |
	beginTypeInBlock == nil ifFalse:
		[(UndoMessage sends: #noUndoer) ifTrue: "should always be true, but just in case..."
			[begin _ self startOfTyping.
			start _ startBlock stringIndex.
			stop _ stopBlock stringIndex.
			self undoer: #undoAndReselect:redoAndReselect:
				with: (begin + UndoMessage argument to: begin + UndoSelection size - 1)
				with: (stop to: stop - 1).
			UndoInterval _ begin to: stop - 1].
		beginTypeInBlock _ nil]