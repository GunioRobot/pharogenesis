markAndTraceCachedContext: cp

	| tmp start limit |
	self inline: true.
	self assertIsCachedContext: cp.
	"Mark the context fields."
	(self isCachedBlockContext: cp) ifTrue: [
		self markAndTrace: (self cachedHomeAt: cp).
	].
	tmp _ self cachedMethodAt: cp.
	self markAndTrace: tmp.
	tmp _ self cachedTranslatedMethodAt: cp.
	self markAndTrace: tmp.
	tmp _ self cachedReceiverAt: cp.
	(self isIntegerObject: tmp) ifFalse: [self markAndTrace: tmp].
	tmp _ self cachedPseudoContextAt: cp.
	tmp = 0 ifFalse: [self markAndTrace: tmp].
	"Mark the stack."
	start _ self cachedFramePointerAt: cp.
	limit _ self cachedStackPointerAt: cp.
	start to: limit by: 4 do: [ :ptr |
		tmp _ self longAt: ptr.
		(self isIntegerObject: tmp) ifFalse: [self markAndTrace: tmp].
	].