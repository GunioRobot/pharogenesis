drawStaffOn: aCanvas

	| blackKeyColor l r topEdge y |
	self drawMeasureLinesOn: aCanvas.

	blackKeyColor _ Color gray: 0.5.
	l _ self left + borderWidth.
	r _ self right - borderWidth.
	topEdge _ self top + borderWidth + 3.
	lowestNote to: 127 do: [:k |
		y _ self yForMidiKey: k.
		y <= topEdge ifTrue: [^ self].  "over the top!"
		(self isBlackKey: k) ifTrue: [
			aCanvas
				fillRectangle: (l@y corner: r@(y + 1))
				color: blackKeyColor]].
