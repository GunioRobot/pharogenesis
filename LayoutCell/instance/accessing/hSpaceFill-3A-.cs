hSpaceFill: aBool
	flags ifNil:[flags _ 0].
	flags _ aBool ifTrue:[flags bitOr: 1] ifFalse:[flags bitClear: 1].
