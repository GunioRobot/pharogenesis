popFloatOnly
	| number |
	(self isIntegerObject: (number _ self popStack)) ifTrue: [
		self success: false.
		^0.0.
	].
	^ self floatValueOf: number