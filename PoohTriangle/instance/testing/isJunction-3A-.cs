isJunction: aBool
	flags _ aBool ifTrue:[flags bitOr: 2] ifFalse:[flags bitClear: 2].