testAsNumberWithRadix

	| sd |
	sd _ '10r-22.2s5' asNumber.
	self assert: ScaledDecimal == sd class.
	self assert: sd scale == 5.
	self assert: '-22.20000s5' = sd printString.