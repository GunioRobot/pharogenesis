methodOfBlockContext: blockContext
	| home cp |
	self assertIsStableBlockContext: blockContext.
	home _ self fetchPointer: HomeIndex ofObject: blockContext.
	(self isPseudoContext: home) ifTrue: [
		cp _ self pseudoCachedContextAt: home.
		^self cachedMethodAt: cp.
	] ifFalse: [
		^self fetchPointer: MethodIndex ofObject: home.
	].
