keyboardPeek
	eventUsed ifFalse: [^ event keyCharacter].
	^ nil