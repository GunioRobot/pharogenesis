hash
	^components inject: 1 into: [ :tally :new |
		(tally bitXor: new hash) hashMultiply ]