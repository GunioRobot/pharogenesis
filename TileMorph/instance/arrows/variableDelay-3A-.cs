variableDelay: aBlock

	| now delay dt |
	nArrowTicks ifNil: [nArrowTicks _ 1].
	now _ Time millisecondClockValue.
	aBlock value.
	delay _ nArrowTicks > 5 ifTrue: [100] ifFalse: [300].
	nArrowTicks _ nArrowTicks + 1.
	dt _ Time millisecondClockValue - now max: 0.  "Time it took to do."
	dt < delay ifTrue: [(Delay forMilliseconds: delay - dt) wait].
