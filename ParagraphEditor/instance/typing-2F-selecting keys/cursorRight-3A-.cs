cursorRight: characterStream 

"Private - Move cursor right one character if nothing selected,
otherwise move cursor to end of selection. If the shift key is down,
start selecting characters or extending already selected characters.
Don't allow cursor past end of text"

	| shift |

	shift := sensor leftShiftDown.
	sensor keyboard.

	shift
		ifTrue: [self selectFrom: startBlock stringIndex to: stopBlock
stringIndex]
		ifFalse: 
			[
			startBlock stringIndex == stopBlock stringIndex
				ifTrue: [self selectFrom: stopBlock stringIndex + 1 to: stopBlock
stringIndex]
				ifFalse: [self selectFrom: stopBlock stringIndex to: stopBlock
stringIndex - 1]
			].

	^true