fillLinearGradientAA: fill ramp: ramp ds: deltaS dsX: dsX from: leftX to: rightX
	"This is the AA version of linear gradient filling."
	| colorMask colorShift baseShift rampIndex ds rampSize x idx rampValue 
	 aaLevel firstPixel lastPixel |
	self inline: false.
	self var: #ramp declareC:'int *ramp'.

	aaLevel _ self aaLevelGet.
	baseShift _ self aaShiftGet.
	rampSize _ self gradientRampLengthOf: fill.
	ds _ deltaS.
	x _ leftX.
	rampIndex _ ds // 16r10000.

	firstPixel _ self aaFirstPixelFrom: leftX to: rightX.
	lastPixel _ self aaLastPixelFrom: leftX to: rightX.

	"Deal with the first n sub-pixels"
	colorMask _ self aaColorMaskGet.
	colorShift _ self aaColorShiftGet.
	[x < firstPixel and:[rampIndex < rampSize and:[rampIndex >= 0]]] whileTrue:[
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		"Copy as many pixels as possible"
		[x < firstPixel and:[(ds//16r10000) = rampIndex]] whileTrue:[
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + rampValue.
			x _ x + 1.
			ds _ ds + dsX].
		rampIndex _ ds // 16r10000.
	].

	"Deal with the full pixels"
	colorMask _ (self aaColorMaskGet >> self aaShiftGet) bitOr: 16rF0F0F0F0.
	colorShift _ self aaShiftGet.
	[x < lastPixel and:[rampIndex < rampSize and:[rampIndex >= 0]]] whileTrue:[
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		"Copy as many pixels as possible"
		[x < lastPixel and:[(ds//16r10000) = rampIndex]] whileTrue:[
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + rampValue.
			x _ x + aaLevel.
			ds _ ds + (dsX << colorShift)].
		rampIndex _ ds // 16r10000.
	].

	"Deal with the last n sub-pixels"
	colorMask _ self aaColorMaskGet.
	colorShift _ self aaColorShiftGet.
	[x < rightX and:[rampIndex < rampSize and:[rampIndex>=0]]] whileTrue:[
		rampValue _ self makeUnsignedFrom: ((self cCoerce: ramp to:'int *') at: rampIndex).
		rampValue _ (rampValue bitAnd: colorMask) >> colorShift.
		"Copy as many pixels as possible"
		[x < rightX and:[(ds//16r10000) = rampIndex]] whileTrue:[
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + rampValue.
			x _ x + 1.
			ds _ ds + dsX].
		rampIndex _ ds // 16r10000.
	].
	^x