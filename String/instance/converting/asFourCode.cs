asFourCode

	|result|
	self size = 4 ifFalse: [^self error: 'must be exactly four characters'].
	result _ self inject: 0 into: [:val :each | 256 * val + each asciiValue].
	(result bitAnd: 16r80000000) = 0 
		ifFalse: [self error: 'cannot resolve fourcode'].
	(result bitAnd: 16r40000000) = 0 ifFalse: [^result - 16r80000000].
	^result