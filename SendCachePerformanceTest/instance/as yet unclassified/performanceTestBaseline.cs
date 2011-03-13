performanceTestBaseline
	LocalSends current for: Morph.
	self assert: [LocalSends current for: Morph] timeToRun < 1.
	Morph clearSendCaches.
	self measure: [LocalSends current for: Morph].
	self assert: realTime < 100.
	self assert: [LocalSends current for: Morph] timeToRun < 1