querySymbol: characterStream
	"Invoked by Ctrl-q to query the Symbol table and display alternate symbols.
	 See comment in completeSymbol:lastOffering: for details."

	sensor keyboard.		"flush character"
	self closeTypeIn: characterStream.	"keep typeahead"
	self hasCaret
		ifTrue: "Ctrl-q typed when a caret"
			[self perform: #completeSymbol:lastOffering: withArguments:
				((UndoParagraph == paragraph and: [UndoMessage sends: #undoQuery:lastOffering:])
					ifTrue: [UndoMessage arguments] "repeated Ctrl-q"
					ifFalse: [Array with: nil with: nil])] "initial Ctrl-q"
		ifFalse: "Ctrl-q typed when statements were highlighted"
			[view flash].
	^true