receiverOfBlockContext: blockContext
	| home cp |
	self assertIsStableBlockContext: blockContext.
	home _ self fetchPointer: HomeIndex ofObject: blockContext.
	(self isPseudoContext: home) ifTrue: [
		cp _ self pseudoCachedContextAt: home.
		^self cachedReceiverAt: cp.
	] ifFalse: [
		^self fetchPointer: ReceiverIndex ofObject: home.
	].
