nextCharFrom: sensor firstEvt: evtBuf

	| keyValue |
	keyValue := evtBuf third.
	evtBuf fifth > 1 ifTrue: [^ keyValue asCharacter squeakToIso].
	^ (self symbolKeyValueToUnicode: keyValue) asCharacter.
