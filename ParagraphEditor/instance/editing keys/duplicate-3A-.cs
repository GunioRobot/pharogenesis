duplicate: characterStream
	"Paste the current selection over the prior selection, if it is non-overlapping and
	 legal.  Flushes typeahead.  Undoer & Redoer: undoAndReselect."

	sensor keyboard.
	self closeTypeIn.
	(startBlock ~= stopBlock and: [self isDisjointFrom: otherInterval])
		ifTrue: "Something to duplicate"
			[self replace: otherInterval with: self selection and:
				[self selectAt: stopBlock stringIndex]]
		ifFalse:
			[view flash].
	^true