isTerminal: aBool
	flags _ aBool ifTrue:[flags bitOr: 8] ifFalse:[flags bitClear: 8].