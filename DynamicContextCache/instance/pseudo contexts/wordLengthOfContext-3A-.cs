wordLengthOfContext: cp
	"Anwer the size in words of the stable context needed to represent the cached context cp."

	| pc meth methodHeader |
	self inline: true.
	self assertIsCachedContext: cp.
	pc _ self cachedPseudoContextAt: cp.
	pc = 0 ifTrue: [
		meth _ self cachedMethodAt: cp.
		methodHeader _ self headerOf: meth.
		((methodHeader >> 18) bitAnd: 1) = 0 ifTrue: [
			^SmallContextSize - BaseHeaderSize // 4.
		] ifFalse: [
			^LargeContextSize - BaseHeaderSize // 4.
		].
	] ifFalse: [
		^self fetchWordLengthOf: pc.
	].