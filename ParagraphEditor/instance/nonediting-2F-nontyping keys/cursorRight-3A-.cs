cursorRight: characterStream 
	"Private - Move cursor right one character if nothing selected, 
	otherwise move cursor to end of selection. If the shift key is down, 
	start selecting characters or extending already selected characters. 
	Don't allow cursor past end of text"
	| shift right |
	self closeTypeIn: characterStream.
	shift _ sensor leftShiftDown.
	right _ stopBlock stringIndex + 1.
	sensor controlKeyPressed ifTrue: [right _ self nextWord: right].
	sensor keyboard.
	shift
		ifTrue: [self selectFrom: startBlock stringIndex to: right - 1]
		ifFalse: [startBlock stringIndex == stopBlock stringIndex
				ifTrue: [self selectAt: right]
				ifFalse: [self selectAt: stopBlock stringIndex]].
	^ true