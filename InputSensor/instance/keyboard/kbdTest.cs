kbdTest    "Sensor kbdTest"
	| char |
	[char = $x] whileFalse: 
		[[self keyboardPressed] whileFalse: [].
		char _ self characterForKeycode: self keyboard.
		char asciiValue printString , '  ' displayAt: 10@10]