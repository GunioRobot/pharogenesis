executeNewMethod

	(primitiveIndex = 0 or: [self primitiveResponse not]) ifTrue: [
		"if not primitive, or primitive failed, activate the method"
		self activateNewMethod.

		"check for possible interrupts at each real send"
		self quickCheckForInterrupts.
	].
