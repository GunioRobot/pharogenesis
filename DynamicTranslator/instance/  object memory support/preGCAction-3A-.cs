preGCAction: fullGCFlag

	fullGCFlag
		ifTrue: [FlushCacheOnFullGC ifTrue: [self flushMethodCache]]
		ifFalse: [FlushCacheOnIncrGC ifTrue: [self flushMethodCache]].