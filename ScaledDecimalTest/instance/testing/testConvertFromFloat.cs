testConvertFromFloat

	| aFloat sd f2 diff |
	aFloat _ 11/13 asFloat.
	sd _ aFloat asScaledDecimal: 2.
	self assert: 2 == sd scale.
	self assert: '0.84s2' = sd printString.
	f2 _ sd asFloat.
	diff _ f2 - aFloat.
	self assert: diff < 1.0e-9. "actually, f = f2, but this is not a requirement"
