keyboard
	"Answer the next character from the keyboard."

	| firstCharacter secondCharactor stream multiCharacter converter |
	firstCharacter _ self characterForKeycode: self primKbdNext.
	secondCharactor _ self characterForKeycode: self primKbdPeek.
	secondCharactor isNil
		ifTrue: [^ firstCharacter].
	converter _ TextConverter defaultSystemConverter.
	converter isNil
		ifTrue: [^ firstCharacter].
	stream _ ReadStream
				on: (String with: firstCharacter with: secondCharactor).
	multiCharacter _ converter nextFromStream: stream.
	multiCharacter isOctetCharacter
		ifTrue: [^ multiCharacter].
	self primKbdNext.
	^ multiCharacter
