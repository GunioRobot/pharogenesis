cursorDown: characterStream 

"Private - Move cursor from position in current line to same position in
next line. If next line too short, put at end. If shift key down,
select."

	| shift string right left start position textSize|

	self closeTypeIn: characterStream.
	shift := sensor leftShiftDown.
	sensor keyboard.

	string _ paragraph text string.
	textSize _ string size.
	left _ right _ stopBlock stringIndex.
	[left > 1 and: [(string at: (left - 1)) ~= Character cr]] whileTrue:
[left _ left - 1].
	position _ stopBlock stringIndex - left.

	[right < textSize and: [(string at: right) ~= Character cr]] whileTrue:
[right _ right + 1].
	right _ start _ right + 1.
	[right < textSize and: [(string at: right) ~= Character cr]] whileTrue:
[right _ right + 1].

	shift
		ifTrue: 
			[
			start + position > right
				ifTrue: [self selectFrom: startBlock stringIndex to: right - 1]
				ifFalse: [self selectFrom: startBlock stringIndex to: start +
position - 1]
			]
		ifFalse: 
			[
			start + position > right
				ifTrue: [self selectFrom: right to: right - 1]
				ifFalse: [self selectFrom: start + position to: start + position -
1]
			].

	^true