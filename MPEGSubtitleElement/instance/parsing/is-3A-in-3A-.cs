is: text in: aStream
	" Returns true if text is present in aStream.
	Advance the stream if present. "

	| position |
	(text isKindOf: Character) ifTrue: [
		^self is: (String with: text) in: aStream
	].
	position := aStream position.
	aStream skipSeparators.
	text = (aStream next: text size) ifFalse: [
		aStream position: position.
		^false
	].
	^true