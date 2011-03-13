completeSymbol: hintText lastOffering: selectorOrNil
	"Invoked by Ctrl-q when there is only a caret.
		Do selector-completion, i.e., try to replace the preceding identifier by a
		selector that begins with those characters & has as many keywords as possible.
	 	Leave two spaces after each colon (only one after the last) as space for
		arguments.  Put the caret after the space after the first keyword.  If the
		user types Ctrl-q again immediately, choose a different selector.
	 Undoer: #undoQuery:lastOffering:; Redoer: itself.
	If redoing, just redisplay the last offering, selector[OrNil]."

	| firstTime input prior caret newStart sym kwds outStream |
	firstTime := self isRedoing
		ifTrue: [prior := sym := selectorOrNil. true]
		ifFalse: [hintText isNil].
	firstTime
		ifTrue: "Initial Ctrl-q (or redo)"					
			[caret := self startIndex.
			self selectPrecedingIdentifier.
			input := self selection]
		ifFalse: "Repeated Ctrl-q"
			[caret := UndoInterval first + hintText size.
			self selectInvisiblyFrom: UndoInterval first to: UndoInterval last.
			input := hintText.
			prior := selectorOrNil].
	(input size ~= 0 and: [sym ~~ nil or:
			[(sym := Symbol thatStarts: input string skipping: prior) ~~ nil]])
		ifTrue: "found something to offer"
			[newStart := self startIndex.
			outStream := (String new: 2 * sym size) writeStream.
			1 to: (kwds := sym keywords) size do:
				[:i |
				outStream nextPutAll: (kwds at: i).
				i = 1 ifTrue: [caret := newStart + outStream contents size + 1].
				outStream nextPutAll:
					(i < kwds size ifTrue: ['  '] ifFalse: [' '])].
			UndoSelection := input.
			self deselect; zapSelectionWith: outStream contents asText.
			self undoer: #undoQuery:lastOffering: with: input with: sym]
		ifFalse: "no more matches"
			[firstTime ifFalse: "restore original text & set up for a redo"
				[UndoSelection := self selection.
				self deselect; zapSelectionWith: input.
				self undoer: #completeSymbol:lastOffering: with: input with: prior.
				Undone := true].
			self flash].
	self selectAt: caret