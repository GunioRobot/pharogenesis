readyForAnotherTick
	"Just call this once, when you need it,
		since it may change lastArrowTick."
	| now delay |
	now _ Time millisecondClockValue.
	delay _ nArrowTicks
		ifNil: [300]
		ifNotNil: [nArrowTicks > 5 ifTrue: [100] ifFalse: [300]].
	(lastArrowTick == nil
		or: [now < lastArrowTick  "clock rollover"
		or: [now > (lastArrowTick + delay)]])
		ifTrue: [lastArrowTick _ now.
				nArrowTicks ifNotNil: [nArrowTicks _ nArrowTicks + 1].
				^ true]
		ifFalse: [^ false]