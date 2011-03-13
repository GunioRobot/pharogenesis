vSpaceFill: aBool
	flags ifNil:[flags _ 0].
	flags _ aBool ifTrue:[flags bitOr: 2] ifFalse:[flags bitClear: 2].
