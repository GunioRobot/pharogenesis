fromCString
	"Assume that the receiver represents a C string and convert it to a Smalltalk string. hg 2/25/2000 14:18"

	| stream index char |
	type isPointerType ifFalse: [self error: 'External object is not a pointer type.'].
	stream _ WriteStream on: String new.
	index _ 1.
	[(char _ handle unsignedCharAt: index) = 0 asCharacter] whileFalse: [
		stream nextPut: char.
		index _ index + 1].
	^stream contents