fillLinearGradient: fill from: leftX to: rightX at: yValue
	"Draw a linear gradient fill."
	| x0 x1 ramp rampSize dsX ds x rampIndex |
	self inline: false.
	self var: #ramp declareC:'int *ramp'.
	ramp _ self gradientRampOf: fill.
	rampSize _ self gradientRampLengthOf: fill.

	dsX _ self fillDirectionXOf: fill.
	ds _ ((leftX - (self fillOriginXOf: fill)) * dsX) + 
			((yValue - (self fillOriginYOf: fill)) * (self fillDirectionYOf: fill)).

	x _ x0 _ leftX.
	x1 _ rightX.

	"Note: The inner loop has been divided into three parts for speed"
	"Part one: Fill everything outside the left boundary"
	[((rampIndex _ ds // 16r10000) < 0 or:[rampIndex >= rampSize]) and:[x < x1]] 
		whileTrue:[	x _ x + 1.
					ds _ ds + dsX].
	x > x0 ifTrue:[
		rampIndex < 0 ifTrue:[rampIndex _ 0].
		rampIndex >= rampSize ifTrue:[rampIndex _ rampSize - 1].
		self fillColorSpan: (self makeUnsignedFrom: (ramp at: rampIndex)) from: x0 to: x].

	"Part two: Fill everything inside the boundaries"
	self aaLevelGet = 1 ifTrue:[
		"Fast version w/o anti-aliasing"
		[((rampIndex _ ds // 16r10000) < rampSize and:[rampIndex >= 0]) and:[x < x1]] whileTrue:[
			spanBuffer at: x put: (self makeUnsignedFrom: (ramp at: rampIndex)).
			x _ x + 1.
			ds _ ds + dsX.
		].
	] ifFalse:[x _ self fillLinearGradientAA: fill ramp: ramp ds: ds dsX: dsX from: x to: rightX].
	"Part three fill everything outside right boundary"
	x < x1 ifTrue:[
		rampIndex < 0 ifTrue:[rampIndex _ 0].
		rampIndex >= rampSize ifTrue:[rampIndex _ rampSize-1].
		self fillColorSpan: (self makeUnsignedFrom: (ramp at: rampIndex)) from: x to: x1].
