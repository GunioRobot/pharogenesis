asFourCode

	| result |
	self size = 1 ifFalse: [^self error: 'must be exactly four octets'].
	result := self basicAt: 1.
	(result bitAnd: 16r80000000) = 0 
		ifFalse: [self error: 'cannot resolve fourcode'].
	(result bitAnd: 16r40000000) = 0 ifFalse: [^result - 16r80000000].
	^ result
