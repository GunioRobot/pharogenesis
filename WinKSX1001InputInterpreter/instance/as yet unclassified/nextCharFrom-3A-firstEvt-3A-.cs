nextCharFrom: sensor firstEvt: evtBuf

	| firstCharacter secondCharacter peekEvent char1Value keyValue pressType type stream multiCharacter |
	keyValue := evtBuf third.
	pressType := evtBuf fourth.
	pressType = EventKeyDown ifTrue: [type := #keyDown].
	pressType = EventKeyUp ifTrue: [type := #keyUp].
	pressType = EventKeyChar ifTrue: [type := #keystroke].

	char1Value _ (Character value: keyValue) macToSqueak asciiValue.
	((char1Value > 127 and: [char1Value < 160])
		or: [char1Value > 223 and: [char1Value < 253]]) ifFalse: [
			^ keyValue asCharacter.
		].

	peekEvent _ sensor peekEvent.
	"peekEvent printString displayAt: 0@0."
	(peekEvent notNil and: [(peekEvent at: 4) = EventKeyDown])
		ifTrue: [sensor nextEvent.
			peekEvent _ sensor peekEvent].
	(type = #keystroke
			and: [peekEvent notNil
					and: [(peekEvent at: 1)
								= EventTypeKeyboard
							and: [(peekEvent at: 4)
									= EventKeyChar]]])
		ifTrue: [
			firstCharacter _ char1Value asCharacter.
			secondCharacter _ (peekEvent at: 3) asCharacter macToSqueak.
			stream _ ReadStream on: (String with: firstCharacter with: secondCharacter).
			multiCharacter _ converter nextFromStream: stream.
			multiCharacter isOctetCharacter ifFalse: [
				sensor nextEvent.
			].
			^ multiCharacter.
		].
	^ keyValue asCharacter.
