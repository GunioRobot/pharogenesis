isValid: aBool
	flags _ aBool ifFalse:[flags bitOr: 1] ifTrue:[flags bitClear: 1].