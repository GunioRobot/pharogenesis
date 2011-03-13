buildScalesIn: frame
	| env hmajortick hminortick |
	env _ envelope.
	pixPerTick _ graphArea width // (self maxTime//10) max: 1.
	hminortick _ ( 1 + ( self maxTime // 800 ) ) * 10.
	hmajortick _ ( 1 + ( self maxTime // 800 ) ) * 100.
	hScale _ (ScaleMorph newBounds: ((graphArea left)@(frame top) corner: (self xFromMs: self maxTime)@(graphArea top - 1)))
		start: 0 stop: self maxTime
		minorTick: hminortick minorTickLength: 3
		majorTick: hmajortick majorTickLength: 10
		caption: 'milliseconds' tickPrintBlock: [:v | v printString].
	self addMorph: hScale.
	vScale _ ScaleMorph newBounds: (0@0 extent: (graphArea height)@(graphArea left - frame left)).
	env name = 'pitch'
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
		ifFalse: [
			env name = 'random pitch:'
				ifTrue: [
					vScale start: 0.9 stop: 1.1
						minorTick: 0.2 / 50.0 minorTickLength: 3
						majorTick: 0.2 / 5.0 majorTickLength: 10
						caption: env name
						tickPrintBlock: [:v | v printString]]
				ifFalse: [
					vScale start: 0 stop: env scale
						minorTick: env scale / 50.0 minorTickLength: 3
						majorTick: env scale / 5.0 majorTickLength: 10
						caption: env name
						tickPrintBlock: [:v | v printString]].
		].
	vScale _ TransformationMorph new asFlexOf: vScale.
	vScale angle: Float pi / 2.0.
	self addMorph: vScale.
	vScale position: (frame left)@(graphArea top-1) - (3@1).
