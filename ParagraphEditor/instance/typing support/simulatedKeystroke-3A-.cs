simulatedKeystroke: char
	"Accept char as if it were struck on the keyboard.  This version does not yet deal with command keys, and achieves update in the receiver's typically inactive window via the sledge-hammer of uncache-bits."

	self deselect.
	self openTypeIn.
	self markBlock = self pointBlock ifFalse: [UndoSelection _ self selection].
	self zapSelectionWith:
		(Text string: char asString emphasis: emphasisHere).
	self userHasEdited.
	self unselect.
	self selectAndScroll.
	self updateMarker.
	view ifNotNil:
		[view topView uncacheBits
		"in mvc, this makes sure the recognized character shows up in the pane right now; in morphic, a different mechanism is used for the same effect -- see TextMorphEditor method #recognizeCharactersWhileMouseIn:"]
