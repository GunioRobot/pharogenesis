buildScalesIn: frame
	| env |
	env _ envelope.
	pixPerTick _ graphArea width // (self maxTime//10) max: 1.
	hScale _ (ScaleMorph newBounds: ((graphArea left)@(frame top) corner: (self xFromMs: self maxTime)@(graphArea top - 1)))
		start: 0 stop: self maxTime
		minorTick: 10 minorTickLength: 3
		majorTick: 100 majorTickLength: 10
		caption: 'milliseconds' tickPrintBlock: [:v | v printString].
	self addMorph: hScale.
	vScale _ ScaleMorph newBounds: (0@0 extent: (graphArea height)@(graphArea left - frame left)).
	env updateSelector = #pitch:
		ifTrue:
		[env scale >= 2.0
			ifTrue:
			[vScale start: 0 stop: env scale
				minorTick: env scale / 24 minorTickLength: 3
				majorTick: env scale / 2.0 majorTickLength: 10
				caption: 'pitch (octaves)'
				tickPrintBlock: [:v | (v-(env scale/2)) asInteger printString]]
			ifFalse:
			[vScale start: 0 stop: env scale
				minorTick: 1.0/48.0 minorTickLength: 3
				majorTick: 1.0/12.0 majorTickLength: 10
				caption: 'pitch (half-steps)'
				tickPrintBlock: [:v | (v-(env scale/2)*12) rounded printString]]]
		ifFalse:
		[vScale start: 0 stop: env scale
			minorTick: env scale / 50.0 minorTickLength: 3
			majorTick: env scale / 5.0 majorTickLength: 10
			caption: env name
			tickPrintBlock: [:v | v printString]].
	vScale _ TransformationMorph new asFlexOf: vScale.
	vScale angle: Float pi / 2.0.
	self addMorph: vScale.
	vScale position: (frame left)@(graphArea top-1).
