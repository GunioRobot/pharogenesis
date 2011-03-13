recognizer: characterStream 
	"Invoke Alan's character recognizer from cmd-r 2/2/96 sw"

	sensor keyboard.
	self recognizeCharacters.
	^ true