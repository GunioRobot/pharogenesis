setRuns: runArray values: valueArray
	| runLength value |
	1 to: runArray size do:[:i|
		runLength _ runArray at: i.
		value _ valueArray at: i.
		self setRunAt: i toLength: runLength value: value.
	].