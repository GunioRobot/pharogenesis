fillRadialIncreasing: fill ramp: ramp deltaST: deltaST dsX: dsX dtX: dtX from: leftX to: rightX
	"Part 2b) Compute the increasing part of the ramp"
	| ds dt rampIndex rampValue length2 x x1 nextLength rampSize lastLength |
	self inline: true.
	ds _ (self cCoerce: deltaST to:'int*') at: 0.
	dt _ (self cCoerce: deltaST to:'int*') at: 1.
	rampIndex _ self accurateLengthOf: ds // 16r10000 with: dt // 16r10000.
	rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
	rampSize _ self gradientRampLengthOf: fill.
	length2 _ (rampSize-1) * (rampSize-1). "This is the upper bound"
	nextLength _ (rampIndex+1) * (rampIndex+1).
	lastLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.

	x _ leftX.
	x1 _ rightX.

	[x < x1 and:[lastLength < length2]] whileTrue:[
		"Try to copy the current value more than once"
		[x < x1 and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) <= nextLength]]
			whileTrue:[	spanBuffer at: x put: rampValue.
						x _ x + 1.
						ds _ ds + dsX.
						dt _ dt + dtX].
		lastLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
		[lastLength > nextLength] whileTrue:[
			rampIndex _ rampIndex + 1.
			rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
			nextLength _ (rampIndex+1) * (rampIndex+1).
		].
	].

	(self cCoerce: deltaST to: 'int *') at: 0 put: ds.
	(self cCoerce: deltaST to: 'int *') at: 1 put: dt.
	^x