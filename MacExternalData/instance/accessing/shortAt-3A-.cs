shortAt: anInteger

	| loc offset |
	loc _ ((anInteger-1) // 2) + 1.
	offset _ 32 - (16*((anInteger-1) \\ 2)).
	^ ((self at: loc) >> offset) bitAnd: 16rFFFF
