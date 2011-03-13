isEmpty
	^(properties isNil or: [properties isEmpty])
	   and: [pragmas isNil or: [pragmas isEmpty]]