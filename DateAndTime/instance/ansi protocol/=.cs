= comparand
	"comparand conforms to protocol DateAndTime,
	or can be converted into something that conforms."
	| comparandAsDateAndTime |
	self == comparand
		ifTrue: [^ true].
	[comparandAsDateAndTime := comparand asDateAndTime]
		on: MessageNotUnderstood
		do: [^ false].
	^ self offset = comparandAsDateAndTime offset
		ifTrue: [self hasEqualTicks: comparandAsDateAndTime ]
		ifFalse: [self asUTC ticks = comparandAsDateAndTime asUTC ticks]
