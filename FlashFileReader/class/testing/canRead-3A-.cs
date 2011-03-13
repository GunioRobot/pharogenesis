canRead: aStream
	"Return true if instances of the receiver know how to handle the data from aStream."
	| ok pos |
	pos := aStream position.
	ok := aStream next asCharacter = $F and:[
			aStream next asCharacter  = $W and:[
				aStream next asCharacter = $S]].
	aStream position: pos.
	^ok