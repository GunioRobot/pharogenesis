nextCharFrom: sensor firstEvt: evtBuf

	| keyValue |
	keyValue := evtBuf third.
	^ keyValue asCharacter squeakToIso.
