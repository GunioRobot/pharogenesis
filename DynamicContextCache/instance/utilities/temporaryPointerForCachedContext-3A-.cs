temporaryPointerForCachedContext: cp
	| home |
	self inline: true.
	self assertIsCachedContext: cp.
	home _ self cachedHomeAt: cp.
	home = 0 ifTrue: [
		^self cachedFramePointerAt: cp.
	] ifFalse: [
		(self isPseudoContext: home) ifTrue: [
			^self cachedFramePointerAt: (self pseudoCachedContextAt: home).
		] ifFalse: [
			^home + BaseHeaderSize + (TempFrameStart * 4).
		].
	].