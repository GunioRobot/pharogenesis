keyboard
	eventUsed ifFalse: [eventUsed _ true.  ^ event keyCharacter].
	^ nil