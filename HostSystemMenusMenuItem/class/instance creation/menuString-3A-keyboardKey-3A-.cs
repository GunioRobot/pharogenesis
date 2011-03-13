menuString: aString keyboardKey: aKey
	^self text: aString cmd: aKey asUppercase handler: 
		(self fakeKeyboardEventBlockascii: aKey unicode: aKey )