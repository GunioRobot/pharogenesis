cursorEnd: characterStream 

"Private - Move cursor end of current line. If cursor already at end of
line, put cursor at end of text"

	| string right stringSize |

	self closeTypeIn: characterStream.
	sensor keyboard.

	string _ paragraph text string.
	stringSize _ string size.
	right _ stopBlock stringIndex.
	[right <= stringSize and: [(string at: right) ~= Character cr]]
		whileTrue: [right _ right + 1].

	sensor commandKeyPressed ifTrue: [right _ stringSize + 1].

	sensor leftShiftDown
		ifTrue: [self selectFrom: startBlock stringIndex to: right - 1]
		ifFalse: [self selectAt: right].

	^true