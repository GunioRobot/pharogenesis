fillRadialDecreasingAA: fill ramp: ramp deltaST: deltaST dsX: dsX dtX: dtX from: leftX to: rightX
	"Part 2a) Compute the decreasing part of the ramp"
	| ds dt rampIndex rampValue length2 x nextLength x1
	aaLevel colorMask colorShift baseShift index firstPixel lastPixel |
	self inline: false.
	self var: #ramp declareC:'int *ramp'.
	self var: #deltaST declareC:' int *deltaST'.

	ds _ (self cCoerce: deltaST to:'int*') at: 0.
	dt _ (self cCoerce: deltaST to:'int*') at: 1.
	aaLevel _ self aaLevelGet.
	baseShift _ self aaShiftGet.
	rampIndex _ self accurateLengthOf: ds // 16r10000 with: dt // 16r10000.
	length2 _ (rampIndex-1) * (rampIndex-1).

	x _ leftX.
	x1 _ self fillOriginXOf: fill.
	x1 > rightX ifTrue:[x1 _ rightX].
	firstPixel _ self aaFirstPixelFrom: leftX to: x1.
	lastPixel _ self aaLastPixelFrom: leftX to: x1.

	"Deal with the first n sub-pixels"
	(x < firstPixel) ifTrue:[
		colorMask _ self aaColorMaskGet.
		colorShift _ self aaColorShiftGet.
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		[x < firstPixel] whileTrue:[
			"Try to copy the current value more than just once"
			[x < firstPixel and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) >= length2]]
				whileTrue:[	index _ x >> baseShift.
							spanBuffer at: index put: (spanBuffer at: index) + rampValue.
							x _ x + 1.
							ds _ ds + dsX.
							dt _ dt + dtX].
			"Step to next ramp value"
			nextLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
			[nextLength < length2] whileTrue:[
				rampIndex _ rampIndex - 1.
				rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
				rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
				length2 _ (rampIndex-1) * (rampIndex-1).
			].
		].
	].

	"Deal with the full pixels"
	(x < lastPixel) ifTrue:[
		colorMask _ (self aaColorMaskGet >> self aaShiftGet) bitOr: 16rF0F0F0F0.
		colorShift _ self aaShiftGet.
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		[x < lastPixel] whileTrue:[
			"Try to copy the current value more than just once"
			[x < lastPixel and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) >= length2]]
				whileTrue:[	index _ x >> baseShift.
							spanBuffer at: index put: (spanBuffer at: index) + rampValue.
							x _ x + aaLevel.
							ds _ ds + (dsX << colorShift).
							dt _ dt + (dtX << colorShift)].
			"Step to next ramp value"
			nextLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
			[nextLength < length2] whileTrue:[
				rampIndex _ rampIndex - 1.
				rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
				rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
				length2 _ (rampIndex-1) * (rampIndex-1).
			].
		].
	].

	"Deal with the last n sub-pixels"
	(x < x1) ifTrue:[
		colorMask _ self aaColorMaskGet.
		colorShift _ self aaColorShiftGet.
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		[x < x1] whileTrue:[
			"Try to copy the current value more than just once"
			[x < x1 and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) >= length2]]
				whileTrue:[	index _ x >> baseShift.
							spanBuffer at: index put: (spanBuffer at: index) + rampValue.
							x _ x + 1.
							ds _ ds + dsX.
							dt _ dt + dtX].
			"Step to next ramp value"
			nextLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
			[nextLength < length2] whileTrue:[
				rampIndex _ rampIndex - 1.
				rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
				rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
				length2 _ (rampIndex-1) * (rampIndex-1).
			].
		].
	].
	"Done -- store stuff back"
	(self cCoerce: deltaST to: 'int *') at: 0 put: ds.
	(self cCoerce: deltaST to: 'int *') at: 1 put: dt.
	^x