allocationRateVal

	| rate allocCount |
	allocCount _ vmParameters at: 4.
	rate _ allocCount < prevAllocCount
		ifTrue: [prevAllocRate]
		ifFalse: [allocCount - prevAllocCount].
	prevAllocCount _ allocCount.
	prevAllocRate _ (prevAllocRate // 2) + (rate // 2).
	^prevAllocRate