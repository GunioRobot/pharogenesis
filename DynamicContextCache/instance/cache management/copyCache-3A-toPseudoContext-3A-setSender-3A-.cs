copyCache: cp toPseudoContext: ctx setSender: senderFlag
	"Copy the cached context cp into the pseudo context ctx.  Mutate ctx into the appropriate
	stable context in the process.  Leave the sender field according to senderFlag, where 'true'
	means use the cached sender (e.g. when ejecting because of overflow), 'false' means nil
	(e.g. when stabilising during return)."

	| sp sz stackSize |
	self inline: false.
	self assertIsCachedContext: cp.
	self assertIsPseudoContext: ctx.
	(self isCachedMethodContext: cp) ifTrue: [
		self mutateToMethodContext: ctx.
		self storePointerUnchecked:	InstructionPointerIndex		ofObject: ctx withValue:	(self cachedInstructionIndexAt: cp).
		self storePointerUnchecked:	StackPointerIndex			ofObject: ctx withValue:	(sp _ self cachedStackIndexAt: cp).
		self storePointerUnchecked:	MethodIndex					ofObject: ctx withValue:	(self cachedMethodAt: cp).
		self storePointerUnchecked:	TranslatedMethodIndex		ofObject: ctx withValue:	(self cachedTranslatedMethodAt: cp).
		self storePointerUnchecked:	ReceiverIndex				ofObject: ctx withValue:	(self cachedReceiverAt: cp).
		"The cached context might have been the home context for a cached block activation -- fix the situation"
"		self redirectTemporaryPointersFrom: (self cachedFramePointerAt: cp)
			to: (ctx + BaseHeaderSize + (TempFrameStart * 4))."
	] ifFalse: [
		self mutateToBlockContext: ctx.
		self storePointerUnchecked:	InstructionPointerIndex		ofObject: ctx withValue:	(self cachedInstructionIndexAt: cp).
		self storePointerUnchecked:	StackPointerIndex			ofObject: ctx withValue:	(sp _ self cachedStackIndexAt: cp).
		self storePointerUnchecked:	BlockArgumentCountIndex	ofObject: ctx withValue:	(self cachedBlockArgumentCountAt: cp).
		self storePointerUnchecked:	InitialIPIndex				ofObject: ctx withValue:	(self cachedInitialIPAt: cp).
		self storePointerUnchecked:	HomeIndex					ofObject: ctx withValue:	(self cachedHomeAt: cp).
	].
	senderFlag ifTrue: [
		self storePointerUnchecked: SenderIndex ofObject: ctx withValue: (self cachedSenderAt: cp).
	] ifFalse: [
		self storePointerUnchecked: SenderIndex ofObject: ctx withValue: nilObj.
	].
	"Copy the stack."
	sz _ ((self sizeBitsOf: ctx) - BaseHeaderSize) // 4 - TempFrameStart.	"12 or 32"
	stackSize _ self integerValueOf: sp.
	stackSize > sz ifTrue: [self error: 'stack overflow while stabilising context'].
	self	inlineTransfer:	stackSize
		wordsFrom:		(self cachedFramePointerAt: cp)
		to:				ctx + BaseHeaderSize + (TempFrameStart * 4).
	"Pseudo-contexts are born full of nil -- no need to fill the rest."
	ctx < youngStart ifTrue: [self beRootIfOld: ctx].
	self assertIsStableContext: ctx.
	self assertIsLegalStackOffsetInContext: ctx.
	^ctx