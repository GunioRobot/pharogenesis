runsFrom: start to: stop do: aBlock
	"Evaluate aBlock with all existing runs in the range from start to stop"
	| run value index |
	start > stop ifTrue:[^self].
	self at: start setRunOffsetAndValue:[:firstRun :offset :firstValue|
		run _ firstRun.
		value _ firstValue.
		index _ start + (runs at: run) - offset.
		[aBlock value: value.
		index <= stop] whileTrue:[
			run _ run + 1.
			value _ values at: run.
			index _ index + (runs at: run)]].
