cursorEnd: characterStream 

"Private - Move cursor end of current line. If cursor already at end of
line, put cursor at end of text"

	| string right stringSize |

	sensor keyboard.

	string _ paragraph text string.
	stringSize _ string size.
	right _ stopBlock stringIndex.
	[right <= stringSize and: [(string at: right) ~= Character cr]]
whileTrue: [right _ right + 1].

	stopBlock stringIndex == right
		ifTrue: [self selectAt: string size + 1]
		ifFalse: [self selectAt: right].

	^true