menuString: aString keyboardKey: aKey virtualKeyValue: aVirtualKeyValue 
	^self text: aString cmd: aKey asUppercase handler: 
		(self fakeKeyboardEventBlockascii: aKey unicode: aKey virtualKey: aVirtualKeyValue)