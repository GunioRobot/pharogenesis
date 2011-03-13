testConvertFromInteger
	"Converting an Integer to a ScaledDecimal yields a ScaledDecimal with
	scale 0, regardless of the scale specified in the #asScaledDecimal: message."

	| sd |
	sd _ 13 asScaledDecimal: 6.
	self assert: 0 = sd scale.
	self assert: ('13s0' = sd printString).
	sd _ -13 asScaledDecimal: 6.
	self assert: 0 = sd scale.
	self assert: ('-13s0' = sd printString).
	sd _ 130000000013 asScaledDecimal: 6.
	self assert: 0 = sd scale.
	self assert: ('130000000013s0' = sd printString).
	sd _ -130000000013 asScaledDecimal: 6.
	self assert: 0 = sd scale.
	self assert: ('-130000000013s0' = sd printString)
