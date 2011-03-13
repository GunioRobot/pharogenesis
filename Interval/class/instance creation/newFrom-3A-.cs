newFrom: aCollection 
	"Answer an instance of me containing the same elements as aCollection."

	| newInterval |
	newInterval _ self from: aCollection first to: aCollection last by:
		(aCollection last - aCollection first)//(aCollection size - 1).
	aCollection ~= newInterval
		ifTrue: [self error: 'The argument is not an arithmetic progression'].
	^newInterval

"	Interval newFrom: {1. 2. 3}
	{33. 5. -23} as: Interval
	{33. 5. -22} as: Interval    (an error)
	(-4 to: -12 by: -1) as: Interval
"