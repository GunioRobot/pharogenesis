nextCharFrom: sensor firstEvt: evtBuf

	| firstChar aCollection bytes peekEvent keyValue type stream multiChar |
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
		aCollection _ OrderedCollection new.
		aCollection add: firstChar.
		bytes _ (keyValue <= 127)
			ifTrue: [ 0 ]
			ifFalse: [ (keyValue bitAnd: 16rE0) = 192
				ifTrue: [ 1 ]
				ifFalse: [ (keyValue bitAnd: 16rF0) = 224
					ifTrue: [ 2 ]
					ifFalse: [ 3 ]
				]
			].
		bytes timesRepeat: [ aCollection add: sensor nextEvent third asCharacter ].
		"aCollection do: [ :each | Transcript show: (each asciiValue hex , ' ')].
		Transcript show: Character cr."
		stream _ ReadStream on: (String withAll: aCollection).
		multiChar _ converter nextFromStream: stream.
		multiChar isOctetCharacter ifFalse: [ sensor nextEvent ].
		^ multiChar].

	^ keyValue asCharacter