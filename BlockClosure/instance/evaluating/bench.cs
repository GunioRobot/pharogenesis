bench
	"See how many times I can value in 5 seconds.  I'll answer a meaningful description."

	| startTime endTime count |
	count _ 0.
	endTime _ Time millisecondClockValue + 5000.
	startTime _ Time millisecondClockValue.
	[ Time millisecondClockValue > endTime ] whileFalse: [ self value.  count _ count + 1 ].
	endTime _ Time millisecondClockValue.
	^count = 1
		ifTrue: [ ((endTime - startTime) // 1000) printString, ' seconds.' ]
		ifFalse:
			[ ((count * 1000) / (endTime - startTime)) asFloat printString, ' per second.' ]