initializeCachedBlockContext: context fromClosure: closure
	"Called by primitiveValue and primitiveValueWithArgs"

	| home initialIP hp method tMethod |
	self inline: true.
	self assertIsStableBlockContext: closure.

	home _ self fetchPointer: HomeIndex ofObject: closure.
	self cachedHomeAt: context put: home.

	(self isPseudoContext: home) ifTrue: [
		hp _ self pseudoCachedContextAt: home.
		method _ (self cachedMethodAt: hp).
		tMethod _ (self cachedTranslatedMethodAt: hp).
		self cachedReceiverAt:			context put: (self cachedReceiverAt: hp).
		self cachedMethodAt:			context put: (method).
		self cachedTranslatedMethodAt:	context put: (tMethod).
"		self cachedTemporaryPointerAt:	context put: (self cachedFramePointerAt: hp)."
		self setTemporaryPointer: (self cachedFramePointerAt: hp).
	] ifFalse: [
		method _ (self fetchPointer: MethodIndex ofObject: home).
		tMethod _ (self fetchPointer: TranslatedMethodIndex ofObject: home).
		self cachedReceiverAt:			context put: (self fetchPointer: ReceiverIndex ofObject: home).
		self cachedMethodAt:			context put: (method).
		self cachedTranslatedMethodAt:	context put: (tMethod).
"		self cachedTemporaryPointerAt:	context put: (home + BaseHeaderSize + (TempFrameStart * 4))."
		self setTemporaryPointer: (home + BaseHeaderSize + (TempFrameStart * 4)).
		home < youngStart ifTrue: [self beRootIfOld: home].
	].

	initialIP _ (self fetchPointer: InitialIPIndex ofObject: closure).
	self cachedInitialIPAt:				context put: initialIP.
	self cachedInstructionIndexAt:		context put: initialIP.
