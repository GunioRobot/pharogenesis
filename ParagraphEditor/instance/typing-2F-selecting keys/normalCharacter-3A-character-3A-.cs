normalCharacter: characterStream character: character
	"A nonspecial character is to be added to the stream of characters."

	characterStream nextPut: character.
	^false