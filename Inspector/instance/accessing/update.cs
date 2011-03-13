update
	"Reshow contents, assuming selected value may have changed."

	selectionIndex = 0
		ifFalse:
			[contents _ self selection printString.
			self changed: #selection.
			self changed: #selectionIndex]