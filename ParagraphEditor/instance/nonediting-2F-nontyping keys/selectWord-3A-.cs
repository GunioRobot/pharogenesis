selectWord: characterStream
	sensor keyboard.
	self closeTypeIn: characterStream.
	self selectWord.
	^ true