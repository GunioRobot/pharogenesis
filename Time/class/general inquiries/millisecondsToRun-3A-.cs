millisecondsToRun: timedBlock 
	"Answer the number of milliseconds timedBlock takes to return its value."

	| initialMilliseconds |
	initialMilliseconds _ self millisecondClockValue.
	timedBlock value.
	^self millisecondsSince: initialMilliseconds