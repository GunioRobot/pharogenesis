cursorLeft: characterStream 

"Private - Move cursor left one character if nothing selected, otherwise
move cursor to beginning of selection. If the shift key is down, start
selecting or extending current selection. Don't allow cursor past
beginning of text"

	| shift |

	shift := sensor leftShiftDown.
	sensor keyboard.

	shift
		ifTrue: 
			[
			startBlock stringIndex > 1
				ifTrue: [self selectFrom: startBlock stringIndex - 1 to: stopBlock
stringIndex - 1]
			]
		ifFalse: 
			[
			(startBlock stringIndex == stopBlock stringIndex and: [startBlock
stringIndex > 1])
				ifTrue: [self selectFrom: startBlock stringIndex - 1 to: startBlock
stringIndex - 2]
				ifFalse: [self selectFrom: startBlock stringIndex to: startBlock
stringIndex - 1]
			].

	^true