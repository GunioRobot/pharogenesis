testAsNumberWithSuperfluousDecimalPoint

	| sd |
	sd _ '123.s2' asNumber.
	self assert: ScaledDecimal == sd class.
	self assert: sd scale == 2.
	self assert: '123.00s2' = sd printString.

