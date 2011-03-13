simulatedKeystroke: char
	"Accept char as if it were struck on the keyboard. This version does not yet deal with command keys, and achieves update in the receiver's typically inactive window via the sledge-hammer of uncache-bits.  1/31/96 sw"

	self deselect.
	self openTypeIn.
	startBlock = stopBlock ifFalse: [UndoSelection _ self selection].
	self zapSelectionWith:
		(Text string: char asString emphasis: emphasisHere).
	self userHasEdited.
	startBlock _ stopBlock copy.
	self selectAndScroll.
	self updateMarker.
	view topView uncacheBits.
