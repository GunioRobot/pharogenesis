showOnDisplay
	"Envelope example showOnDisplay"

	| xOrigin yOrigin minVal maxVal yScale step x v y |
	xOrigin _ 30.
	yOrigin _ 130.
	minVal _ 1e100.
	maxVal _ -1e100.
	points do: [:p |
		p y < minVal ifTrue: [minVal _ p y].
		p y > maxVal ifTrue: [maxVal _ p y]].

	yScale _ 100.0 / ((maxVal - minVal) * scale).
	step _ (self duration // 150) max: 1.

	Display fillBlack: ((xOrigin + ((points at: loopStartIndex) x // step))@(yOrigin - 100) extent: 1@100).
	Display fillBlack: ((xOrigin + ((points at: loopEndIndex) x // step))@(yOrigin - 100) extent: 1@100).
	Display fillBlack: (xOrigin@(yOrigin - 100) extent: 1@100).
	x _ xOrigin.
	step negated to: self duration + step by: step do: [:mSecs |
		v _ self computeValueAtMSecs: mSecs.
		y _ yOrigin - ((v - minVal) * yScale) asInteger.
		Display fillBlack: ((x - 1)@(y - 1) extent: 2@2).
		Display fillBlack: (x@yOrigin extent: 1@1).
		x _ x + 1].
