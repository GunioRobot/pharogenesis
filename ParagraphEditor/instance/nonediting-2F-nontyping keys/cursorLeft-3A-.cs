cursorLeft: characterStream 
	"Private - Move cursor left one character if nothing selected, otherwise 
	move cursor to beginning of selection. If the shift key is down, start 
	selecting or extending current selection. Don't allow cursor past 
	beginning of text"
	| shift left |
	self closeTypeIn: characterStream.
	shift _ sensor leftShiftDown.
	left _ startBlock stringIndex - 1.
	sensor controlKeyPressed ifTrue: [left _ self previousWord: left].
	sensor keyboard.
	shift
		ifTrue: [startBlock stringIndex > 1
			ifTrue: [self selectFrom: left to: stopBlock stringIndex - 1]]
		ifFalse: [(startBlock stringIndex == stopBlock stringIndex and: [startBlock stringIndex > 1])
			ifTrue: [self selectAt: left]
			ifFalse: [self selectAt: startBlock stringIndex]].
	^ true