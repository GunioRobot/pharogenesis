cursorHome: characterStream 

"Private - Move cursor from position in current line to beginning of
current line. If cursor already at beginning of line, put cursor at
beginning of text"

	| string left |

	self closeTypeIn: characterStream.
	sensor keyboard.

	string _ paragraph text string.
	left _ startBlock stringIndex.
	[left > 1 and: [(string at: (left - 1)) ~= Character cr]]
		whileTrue: [left _ left - 1].

	sensor commandKeyPressed ifTrue: [left _ 1].

	sensor leftShiftDown
		ifTrue: [self selectFrom: left to: stopBlock stringIndex - 1]
		ifFalse: [self selectAt: left].

	^true