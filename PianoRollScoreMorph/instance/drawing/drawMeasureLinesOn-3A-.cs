drawMeasureLinesOn: aCanvas

	| ticksPerMeas x measureLineColor inner |
	showBeatLines ifNil: [showBeatLines _ false].
	showMeasureLines ifNil: [showMeasureLines _ true].
	notePerBeat ifNil: [self timeSignature: 4 over: 4].
	showBeatLines ifTrue:
		[measureLineColor _ Color gray: 0.8.
		ticksPerMeas _ score ticksPerQuarterNote.
		inner _ self innerBounds.
		(leftEdgeTime + ticksPerMeas truncateTo: ticksPerMeas)
			to: ((self timeForX: self right - borderWidth) truncateTo: ticksPerMeas)
			by: ticksPerMeas
			do: [:tickTime | x _ self xForTime: tickTime.
				aCanvas fillRectangle: (x @ inner top extent: 1 @ inner height)
					color: measureLineColor]].

	showMeasureLines ifTrue:
		[measureLineColor _ Color gray: 0.7.
		ticksPerMeas _ beatsPerMeasure*score ticksPerQuarterNote*4//notePerBeat.
		inner _ self innerBounds.
		(leftEdgeTime + ticksPerMeas truncateTo: ticksPerMeas)
			to: ((self timeForX: self right - borderWidth) truncateTo: ticksPerMeas)
			by: ticksPerMeas
			do: [:tickTime | x _ self xForTime: tickTime.
				aCanvas fillRectangle: (x @ inner top extent: 1 @ inner height)
						color: (tickTime = 0 ifTrue: [Color black] ifFalse: [measureLineColor])]].
