fillRadialDecreasing: fill ramp: ramp deltaST: deltaST dsX: dsX dtX: dtX from: leftX to: rightX
	"Part 2a) Compute the decreasing part of the ramp"
	| ds dt rampIndex rampValue length2 x x1 nextLength |
	self inline: true.
	ds _ (self cCoerce: deltaST to:'int*') at: 0.
	dt _ (self cCoerce: deltaST to:'int*') at: 1.
	rampIndex _ self accurateLengthOf: ds // 16r10000 with: dt // 16r10000.
	rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
	length2 _ (rampIndex-1) * (rampIndex-1).

	x _ leftX.
	x1 _ rightX.
	x1 > (self fillOriginXOf: fill) ifTrue:[x1 _ self fillOriginXOf: fill].
	[x < x1] whileTrue:[
		"Try to copy the current value more than just once"
		[x < x1 and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) >= length2]]
			whileTrue:[	spanBuffer at: x put: rampValue.
						x _ x + 1.
						ds _ ds + dsX.
						dt _ dt + dtX].
		"Step to next ramp value"
		nextLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
		[nextLength < length2] whileTrue:[
			rampIndex _ rampIndex - 1.
			rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
			length2 _ (rampIndex-1) * (rampIndex-1).
		].
	].

	(self cCoerce: deltaST to: 'int *') at: 0 put: ds.
	(self cCoerce: deltaST to: 'int *') at: 1 put: dt.
	^x