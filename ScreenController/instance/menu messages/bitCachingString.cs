bitCachingString
	^ StandardSystemView cachingBits
		ifTrue: ['don''t save bits (compact)']
		ifFalse: ['save bits (fast)']