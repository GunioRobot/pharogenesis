isSleeve: aBool
	flags _ aBool ifTrue:[flags bitOr: 4] ifFalse:[flags bitClear: 4].