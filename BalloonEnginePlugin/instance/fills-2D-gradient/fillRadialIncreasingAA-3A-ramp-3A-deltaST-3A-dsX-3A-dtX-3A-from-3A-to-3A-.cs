fillRadialIncreasingAA: fill ramp: ramp deltaST: deltaST dsX: dsX dtX: dtX from: leftX to: rightX
	"Part 2b) Compute the increasing part of the ramp"
	| ds dt rampIndex rampValue length2 x nextLength rampSize lastLength 
	aaLevel colorMask colorShift baseShift index firstPixel lastPixel |
	self inline: false.
	self var: #ramp declareC:'int *ramp'.
	self var: #deltaST declareC:' int *deltaST'.

	ds _ (self cCoerce: deltaST to:'int*') at: 0.
	dt _ (self cCoerce: deltaST to:'int*') at: 1.
	aaLevel _ self aaLevelGet.
	baseShift _ self aaShiftGet.
	rampIndex _ self accurateLengthOf: ds // 16r10000 with: dt // 16r10000.
	rampSize _ self gradientRampLengthOf: fill.
	length2 _ (rampSize-1) * (rampSize-1). "This is the upper bound"
	nextLength _ (rampIndex+1) * (rampIndex+1).
	lastLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.

	x _ leftX.

	firstPixel _ self aaFirstPixelFrom: leftX to: rightX.
	lastPixel _ self aaLastPixelFrom: leftX to: rightX.

	"Deal with the first n subPixels"
	(x < firstPixel and:[lastLength < length2]) ifTrue:[
		colorMask _ self aaColorMaskGet.
		colorShift _ self aaColorShiftGet.
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		[x < firstPixel and:[lastLength < length2]] whileTrue:[
			"Try to copy the current value more than once"
			[x < firstPixel and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) <= nextLength]]
				whileTrue:[	index _ x >> baseShift.
							spanBuffer at: index put: (spanBuffer at: index) + rampValue.
							x _ x + 1.
							ds _ ds + dsX.
							dt _ dt + dtX].
			lastLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
			[lastLength > nextLength] whileTrue:[
				rampIndex _ rampIndex + 1.
				rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
				rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
				nextLength _ (rampIndex+1) * (rampIndex+1).
			].
		].
	].

	"Deal with the full pixels"
	(x < lastPixel and:[lastLength < length2]) ifTrue:[
		colorMask _ (self aaColorMaskGet >> self aaShiftGet) bitOr: 16rF0F0F0F0.
		colorShift _ self aaShiftGet.
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		[x < lastPixel and:[lastLength < length2]] whileTrue:[
			"Try to copy the current value more than once"
			[x < lastPixel and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) <= nextLength]]
				whileTrue:[	index _ x >> baseShift.
							spanBuffer at: index put: (spanBuffer at: index) + rampValue.
							x _ x + aaLevel.
							ds _ ds + (dsX << colorShift).
							dt _ dt + (dtX << colorShift)].
			lastLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
			[lastLength > nextLength] whileTrue:[
				rampIndex _ rampIndex + 1.
				rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
				rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
				nextLength _ (rampIndex+1) * (rampIndex+1).
			].
		].
	].

	"Deal with last n sub-pixels"
	(x < rightX and:[lastLength < length2]) ifTrue:[
		colorMask _ self aaColorMaskGet.
		colorShift _ self aaColorShiftGet.
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		[x < rightX and:[lastLength < length2]] whileTrue:[
			"Try to copy the current value more than once"
			[x < rightX and:[(self squaredLengthOf: ds //  16r10000 with: dt // 16r10000) <= nextLength]]
				whileTrue:[	index _ x >> baseShift.
							spanBuffer at: index put: (spanBuffer at: index) + rampValue.
							x _ x + 1.
							ds _ ds + dsX.
							dt _ dt + dtX].
			lastLength _ self squaredLengthOf: ds //  16r10000 with: dt // 16r10000.
			[lastLength > nextLength] whileTrue:[
				rampIndex _ rampIndex + 1.
				rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
				rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
				nextLength _ (rampIndex+1) * (rampIndex+1).
			].
		].
	].
	"Done -- store stuff back"
	(self cCoerce: deltaST to: 'int *') at: 0 put: ds.
	(self cCoerce: deltaST to: 'int *') at: 1 put: dt.
	^x