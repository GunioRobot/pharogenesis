tocKeystroke: aCharacter 
	(aCharacter = Character backspace or: [ aCharacter = Character delete or: [ aCharacter = $d ]])
		ifTrue: [self deleteMessage].
	(aCharacter asciiValue = 30 or: [ aCharacter = $p ])
		ifTrue: [self previousMessage].
	(aCharacter asciiValue = 31 or: [ aCharacter = $n ])
		ifTrue: [self nextMessage].
	aCharacter = $n
		ifTrue: [self addNamedFilter].
	aCharacter = $s
		ifTrue: [self addSubjectFilter]
