cursorUp: characterStream 

"Private - Move cursor from position in current line to same position in
prior line. If prior line too short, put at end"

	| shift string left position start |

	self closeTypeIn: characterStream.
	shift := sensor leftShiftDown.
	sensor keyboard.

	string _ paragraph text string.
	left _ startBlock stringIndex.
	[left > 1 and: [(string at: (left - 1)) ~= Character cr]] whileTrue:
[left _ left - 1].
	position _ startBlock stringIndex - left.
	start _ left.

	left _ left - 1.
	[left > 1 and: [(string at: (left - 1)) ~= Character cr]] whileTrue:
[left _ left - 1].

	left < 1 ifTrue: [left _ 1].
	start = 1 ifTrue: [position _ 0].
	shift
		ifTrue: 
			[
			(start - left < position and: [start > 1])
				ifTrue: [self selectFrom: start - 1 to: stopBlock stringIndex - 1]
				ifFalse: [self selectFrom: left + position to: stopBlock stringIndex
- 1]
			]
		ifFalse: 
			[
			(start - left < position and: [start > 1])
				ifTrue: [self selectFrom: start - 1 to: start - 2]
				ifFalse: [self selectFrom: left + position to: left + position - 1]
			].

	^true