nextStringIs: aString in: aStream
	"If the next characters of the given stream form the given string, then advance the stream position by the size of the string and return true. Otherwise, leave the stream untouched and return false."

	| oldPosition |
	oldPosition _ aStream position.
	1 to: aString size do: [ :i |
		aStream next = (aString at: i) ifFalse: [
			aStream position: oldPosition.
			^false
		].
	].
	aStream position: oldPosition.
	^true