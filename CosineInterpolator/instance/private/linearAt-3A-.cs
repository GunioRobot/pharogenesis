linearAt: time
	"Answer the value of the receiver at a given time. (Do linear interpolation.)"
	| xVal count x1 x2 y1 y2 |
	points isNil ifTrue: [^ nil].
	xVal _ points first key.
	count _ 1.
	[xVal < time]
		whileTrue: [count _ count + 1.
					count > points size ifTrue: [^ points last value].
					xVal _ (points at: count) key].
	xVal = time ifTrue: [^ (points at: count) value].
	count = 1 ifTrue: [^ points first value].
	x1 _ (points at: count - 1) key.
	x2 _ (points at: count) key.
	y1 _ (points at: count - 1) value.
	y2 _ (points at: count) value.
	^ (time - x1) / (x2 - x1) * (y2 - y1) + y1