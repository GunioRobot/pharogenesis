pitchAt: time
	"Answer the pitch of the receiver at a given time. (Do linear interpolation.)"
	| xVal count x1 x2 y1 y2 |
	pitchPoints isNil ifTrue: [^ nil].
	xVal _ pitchPoints first x.
	count _ 1.
	[xVal < time]
		whileTrue: [count _ count + 1.
					count > pitchPoints size ifTrue: [^ pitchPoints last y].
					xVal _ (pitchPoints at: count) x].
	xVal = time ifTrue: [^ (pitchPoints at: count) y].
	count = 1 ifTrue: [^ pitchPoints first y].
	x1 _ (pitchPoints at: count - 1) x.
	x2 _ (pitchPoints at: count) x.
	y1 _ (pitchPoints at: count - 1) y.
	y2 _ (pitchPoints at: count) y.
	^ (time - x1) / (x2 - x1) * (y2 - y1) + y1