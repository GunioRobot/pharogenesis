copyContextToCache: ctx
	"Copy ctx into the first context cache location, resetting activeCachedContext in the process.
	Mutate the source context into a PseudoContext in the process.
	Assumes:	ctx is the topmost context in the stable stack.
				The context cache is initially empty.
	Notes:		If ctx is a BlockContext, the home context is guaranteed to be stable."

	| cp sp home |
	self inline: false.

	self assertIsStableContext: ctx.

	"Reset the context cache to initial conditions."
	cp _ lowestCachedContext _ activeCachedContext _ contextCache.
	self initializeCachedContext: cp.
	self cachedFramePointerAt: cp put: stackCache.

	(self isMethodContext: ctx) ifTrue: [
		self cachedMethodAt:				cp put: (self fetchPointer: MethodIndex				ofObject: ctx).
		self cachedTranslatedMethodAt:		cp put: (self fetchPointer: TranslatedMethodIndex		ofObject: ctx).
		self cachedReceiverAt:				cp put: (self fetchPointer: ReceiverIndex				ofObject: ctx).
		self cachedHomeAt:					cp put: 0.
		self cachedSenderAt:					cp put: (self fetchPointer: SenderIndex				ofObject: ctx).
		self cachedInstructionIndexAt:		cp put: (self fetchPointer: InstructionPointerIndex	ofObject: ctx).
		self cachedStackIndexAt:				cp put: (self fetchPointer: StackPointerIndex			ofObject: ctx).
"		self cachedTemporaryPointerAt:		cp put: stackCache."
	] ifFalse: [
		home _ self fetchPointer: HomeIndex ofObject: ctx.
		self cachedHomeAt:					cp put: (home).
		self cachedMethodAt:				cp put: (self methodOfBlockContext: ctx).
		self cachedTranslatedMethodAt:		cp put: (self translatedMethodOfBlockContext: ctx).
		self cachedReceiverAt:				cp put: (self receiverOfBlockContext: ctx).
		self cachedCallerAt:					cp put: (self fetchPointer: CallerIndex				ofObject: ctx).
		self cachedInstructionIndexAt:		cp put: (self fetchPointer: InstructionPointerIndex	ofObject: ctx).
		self cachedStackIndexAt:				cp put: (self fetchPointer: StackPointerIndex			ofObject: ctx).
		self cachedBlockArgumentCountAt:	cp put: (self fetchPointer: BlockArgumentCountIndex	ofObject: ctx).
		self cachedInitialIPAt:				cp put: (self fetchPointer: InitialIPIndex				ofObject: ctx).
		self assertIsStableMethodContext: home.
"		self cachedTemporaryPointerAt:		cp put: (home + BaseHeaderSize + (TempFrameStart * 4))."
"		home < youngStart ifTrue: [self beRootIfOld: home]."
	].
	"Copy the stack"
	sp _ self quickFetchInteger: StackPointerIndex ofObject: ctx.
	self	inlineTransfer:	sp
			wordsFrom:	ctx + BaseHeaderSize + (TempFrameStart * 4)
			to:			(self cachedFramePointerAt: cp).
	"Unused stack locations are ignored by GC -- no need to fill with nil"
	self mutateToPseudoContext: ctx.		"fills with nil in the process"
	self cachedPseudoContextAt: cp put: ctx.
	self pseudoCachedContextAt: ctx put: cp.
	self assertIsValidPseudoContextAt: cp.
	ctx < youngStart ifTrue: [self beRootIfOld: ctx]		"*** I DON'T THINK THIS IS NEEDED (there are no real pointers in it!) ***"
