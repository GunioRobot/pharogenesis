isBorderEdge: aBool
	flags _ aBool ifTrue:[flags bitOr: 1] ifFalse:[flags bitClear: 1].