step
	stream atEnd ifTrue: [^self reportLastMatch].
	currentCharacter := stream next.
	outputStream nextPut: currentCharacter