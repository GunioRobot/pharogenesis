localReturn: value
	self inline: true.
	self sharedCodeNamed: 'commonLocalReturn' inCase: CommonLocalReturnCase.
	self assertStackPointerIsInternal.

	(self cachedSenderAt: localCP) = nilObj ifTrue: [
		self externalizeIPandSP.
		self cannotReturn: value.
		self internalizeIPandSP.
		^nil
	].
	self deallocateCachedContext.
	self internalFetchContextRegisters.
	self internalPush: value.
	self internalQuickCheckForInterrupts.