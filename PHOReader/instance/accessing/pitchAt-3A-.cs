pitchAt: t
	"Answer the pitch of the receiver at a given time. (Do linear interpolation.)"
	| xVal count x1 x2 y1 y2 |
	xVal := pitches first x.
	count := 1.
	[xVal < t]
		whileTrue: [count := count + 1.
					count > pitches size ifTrue: [^ pitches last y].
					xVal := (pitches at: count) x].
	xVal = t ifTrue: [^ (pitches at: count) y].
	count = 1 ifTrue: [^ pitches first y].
	x1 := (pitches at: count - 1) x.
	x2 := (pitches at: count) x.
	y1 := (pitches at: count - 1) y.
	y2 := (pitches at: count) y.
	^ (t - x1) / (x2 - x1) * (y2 - y1) + y1