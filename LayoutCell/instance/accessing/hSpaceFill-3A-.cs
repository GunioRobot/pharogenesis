hSpaceFill: aBool
	flags _ aBool ifTrue:[self flags bitOr: 1] ifFalse:[self flags bitClear: 1].
