nextCharFrom: sensor firstEvt: evtBuf

	| firstChar secondChar peekEvent keyValue type stream multiChar |
	keyValue _ evtBuf third.
	evtBuf fourth = EventKeyChar ifTrue: [type _ #keystroke].
	peekEvent _ sensor peekEvent.
	(peekEvent notNil and: [peekEvent fourth = EventKeyDown]) ifTrue: [
		sensor nextEvent.
		peekEvent _ sensor peekEvent].

	(type == #keystroke
	and: [peekEvent notNil 
	and: [peekEvent first = EventTypeKeyboard
	and: [peekEvent fourth = EventKeyChar]]]) ifTrue: [
		firstChar _ keyValue asCharacter.
		secondChar _ (peekEvent third) asCharacter.
		stream _ ReadStream on: (String with: firstChar with: secondChar).
		multiChar _ converter nextFromStream: stream.
		multiChar isOctetCharacter ifFalse: [sensor nextEvent].
		^ multiChar].

	^ keyValue asCharacter