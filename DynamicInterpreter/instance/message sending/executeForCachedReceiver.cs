executeForCachedReceiver
	"Execute newMethod for a cached receiver, which might or might not be the activeCachedContext"

	| cp |
	self inline: false.

	self assert: pseudoReceiver = newReceiver.
	cp _ self pseudoCachedContextAt: pseudoReceiver.
	self assert: (self cachedPseudoContextAt: cp) = pseudoReceiver.
	cp = activeCachedContext ifTrue: [
		(primitiveIndex = 0 or: [self primitiveResponseForCachedReceiver not]) ifTrue: [
			"Bail out and perform a full activation.  This case is extremely rare,
			and will get even rarer once the #release anachronisms in Process>>terminate
			(left over from the days of reference counting) are removed from the image."
			self activateNewMethod.		"...which cleans up the receiver situation for us"
			self quickCheckForInterrupts.
		].
		pseudoReceiver _ 0.
	] ifFalse: [
		self flushCacheFrom: cp.
		self assertIsStableContext: newReceiver.
		pseudoReceiver _ 0.
		(primitiveIndex = 0 or: [self primitiveResponse not]) ifTrue: [
			"if not primitive, or primitive failed, activate the method"
			self activateNewMethod.
			"check for possible interrupts at each real send"
			self quickCheckForInterrupts.
		].
	].