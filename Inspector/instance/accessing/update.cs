update
	"Reshow contents, assuming selected value may have changed."

	selectionIndex = 0
		ifFalse:
			[self contentsIsString
				ifTrue: [contents _ self selection]
				ifFalse: [contents _ self selectionPrintString].
			self changed: #contents.
			self changed: #selection.
			self changed: #selectionIndex]