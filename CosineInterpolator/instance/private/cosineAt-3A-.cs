cosineAt: time
	"Answer the value of the receiver at a given time. (Do cosine interpolation.)"
	| xVal count x1 x2 y1 y2 |
	points isNil ifTrue: [^ nil].
	xVal := points first key.
	count := 1.
	[xVal < time]
		whileTrue: [count := count + 1.
					count > points size ifTrue: [^ points last value].
					xVal := (points at: count) key].
	xVal = time ifTrue: [^ (points at: count) value].
	count = 1 ifTrue: [^ points first value].
	x1 := (points at: count - 1) key.
	x2 := (points at: count) key.
	y1 := (points at: count - 1) value.
	y2 := (points at: count) value.
	^ ((time - x1 / (x2 - x1) * Float pi) cos - 1 / -2.0) * (y2 - y1) + y1