kbdTest    "Sensor kbdTest"
	"This test routine will print the unmodified character, its keycode,
	and the OR of all its modifier bits, until the character x is typed"
	| char |
	char _ nil.
	[char = $x] whileFalse: 
		[[self keyboardPressed] whileFalse: [].
		char _ self characterForKeycode: self keyboard.
		(String streamContents: 
			[:s | s nextPut: char; space; print: char asciiValue;
					space; print: self primMouseButtons; nextPutAll: '     '])
			displayAt: 10@10]