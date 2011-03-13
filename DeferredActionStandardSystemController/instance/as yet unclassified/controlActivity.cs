controlActivity
	[queue isEmpty]
		whileFalse: [queue next value].
	^super controlActivity