tocKeystroke: aCharacter 
	aCharacter = Character backspace
		ifTrue: [self deleteMessage].
	aCharacter asciiValue = 30
		ifTrue: [self previousMessage].
	aCharacter asciiValue = 31
		ifTrue: [self nextMessage].
	aCharacter = $c
		ifTrue: [self customFilterOn].
	aCharacter = $m
		ifTrue: [self customFilterMove].
	aCharacter = $s
		ifTrue: [self subjectFilterOn]
