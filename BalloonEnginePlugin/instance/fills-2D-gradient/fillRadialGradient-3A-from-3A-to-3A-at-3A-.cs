fillRadialGradient: fill from: leftX to: rightX at: yValue
	"Draw a radial gradient fill."
	| x x1 ramp rampSize dsX ds dtX dt length2 deltaX deltaY deltaST |
	self inline: false.
	self var: #ramp declareC:'int *ramp'.
	self var: #deltaST declareC:'int *deltaST'.

	ramp _ self gradientRampOf: fill.
	rampSize _ self gradientRampLengthOf: fill.

	deltaX _ leftX - (self fillOriginXOf: fill).
	deltaY _ yValue - (self fillOriginYOf: fill).

	dsX _ self fillDirectionXOf: fill.
	dtX _ self fillNormalXOf: fill.

	ds _ (deltaX * dsX) + (deltaY * (self fillDirectionYOf: fill)).
	dt _ (deltaX * dtX) + (deltaY * (self fillNormalYOf: fill)).

	x _ leftX.
	x1 _ rightX.

	"Note: The inner loop has been divided into three parts for speed"
	"Part one: Fill everything outside the left boundary"
	length2 _ (rampSize-1) * (rampSize-1). "This is the upper bound"
	[(self squaredLengthOf: ds // 16r10000 with: dt // 16r10000) >= length2 and:[x < x1]]
		whileTrue:[	x _ x + 1.	ds _ ds + dsX.	dt _ dt + dtX].
	x > leftX ifTrue:[self fillColorSpan: (self makeUnsignedFrom: (ramp at: rampSize-1)) from: leftX to: x].

	"Part two: Fill everything inside the boundaries"
	deltaST _ self point1Get.
	deltaST at: 0 put: ds.
	deltaST at: 1 put: dt.
	(x < (self fillOriginXOf: fill)) ifTrue:[
		"Draw the decreasing part"
		self aaLevelGet = 1 
			ifTrue:[x _ self fillRadialDecreasing: fill ramp: ramp deltaST: deltaST 
							dsX: dsX dtX: dtX from: x to: x1]
			ifFalse:[x _ self fillRadialDecreasingAA: fill ramp: ramp deltaST: deltaST 
							dsX: dsX dtX: dtX from: x to: x1].
	].
	x < x1 ifTrue:[
		"Draw the increasing part"
		self aaLevelGet = 1
			ifTrue:[x _ self fillRadialIncreasing: fill ramp: ramp deltaST: deltaST
							dsX: dsX dtX: dtX from: x to: x1]
			ifFalse:[x _ self fillRadialIncreasingAA: fill ramp: ramp deltaST: deltaST
							dsX: dsX dtX: dtX from: x to: x1].
	].

	"Part three fill everything outside right boundary"
	x < rightX ifTrue:[self fillColorSpan: (self makeUnsignedFrom: (ramp at: rampSize-1)) from: x to: rightX].
