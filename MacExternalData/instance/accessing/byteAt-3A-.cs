byteAt: anInteger

	| loc offset |
	loc _ ((anInteger-1) // 4) + 1.
	offset _ 24 - (8*((anInteger-1) \\ 4)).
	^ ((self at: loc) >> offset) bitAnd: 16rFF
