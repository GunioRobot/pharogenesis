contextCacheDepth: b
	^b isPseudoContext
		ifTrue: [1 + (self contextCacheDepth: b)]
		ifFalse: [1]