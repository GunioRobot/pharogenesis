tocKeystroke: aCharacter

	aCharacter = Character backspace ifTrue: [self deleteMessage].
	aCharacter asciiValue = 30 ifTrue: [self previousMessage].
	aCharacter asciiValue = 31 ifTrue: [self nextMessage].
