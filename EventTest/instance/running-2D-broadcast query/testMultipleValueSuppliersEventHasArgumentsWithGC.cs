testMultipleValueSuppliersEventHasArgumentsWithGC

	eventSource
		when: #needsValue:
		send: #getFalse:
		to: self
		with: Object new.
	eventSource
		when: #needsValue:
		send: #getTrue:
		to: self
		with: Object new.
	Smalltalk garbageCollectMost.
	succeeded := eventSource triggerEvent: #needsValue: with: 'kolme'.
	self should: [succeeded = nil]
