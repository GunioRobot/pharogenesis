checkSend: tMeth to: rcvr data: data nArgs: nArgs type: type

	| prevData cacheHit prevCycle |
	self inline: true.

	prevData _ self fetchPointer: MethodLinkageIndex ofObject: tMeth.
	EagerInlineCacheFlush ifTrue: [
		cacheHit _ (data = prevData).
	] ifFalse: [
		prevCycle _ self fetchPointer: MethodCycleIndex ofObject: tMeth.
		cacheHit _ (data = prevData and: [prevCycle = translationCycle]).
	].
	cacheHit ifTrue: [
		statInlineCacheHits _ statInlineCacheHits + 1.
		self executeLinkedSend: tMeth to: rcvr nArgs: nArgs.
	] ifFalse: [
		self relinkSend: tMeth to: rcvr nArgs: nArgs type: type.
	]