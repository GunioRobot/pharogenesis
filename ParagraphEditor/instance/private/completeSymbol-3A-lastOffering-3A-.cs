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
	firstTime _ self isRedoing
		ifTrue: [prior _ sym _ selectorOrNil. true]
		ifFalse: [hintText isNil].
	firstTime
		ifTrue: "Initial Ctrl-q (or redo)"					
			[caret _ self startIndex.
			self selectPrecedingIdentifier.
			input _ self selection]
		ifFalse: "Repeated Ctrl-q"
			[caret _ UndoInterval first + hintText size.
			self selectInvisiblyFrom: UndoInterval first to: UndoInterval last.
			input _ hintText.
			prior _ selectorOrNil].
	(input size ~= 0 and: [sym ~~ nil or:
			[(sym _ Symbol thatStarts: input string skipping: prior) ~~ nil]])
		ifTrue: "found something to offer"
			[newStart _ self startIndex.
			outStream _ WriteStream on: (String new: 2 * sym size).
			1 to: (kwds _ sym keywords) size do:
				[:i |
				outStream nextPutAll: (kwds at: i).
				i = 1 ifTrue: [caret _ newStart + outStream contents size + 1].
				outStream nextPutAll:
					(i < kwds size ifTrue: ['  '] ifFalse: [' '])].
			UndoSelection _ input.
			self deselect; zapSelectionWith: outStream contents asText.
			self undoer: #undoQuery:lastOffering: with: input with: sym]
		ifFalse: "no more matches"
			[firstTime ifFalse: "restore original text & set up for a redo"
				[UndoSelection _ self selection.
				self deselect; zapSelectionWith: input.
				self undoer: #completeSymbol:lastOffering: with: input with: prior.
				Undone _ true].
			view flash].
	self selectAt: caret