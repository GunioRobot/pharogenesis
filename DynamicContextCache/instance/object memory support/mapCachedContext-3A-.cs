mapCachedContext: cp
	"Notes:	the stack and instruction pointers are raw."

	| tmp start limit ip meth |
	self inline: true.
	self assertIsCachedContext: cp.
	"Map the context fields."
	(self basicIsCachedMethodContext: cp) ifFalse: [
		tmp _ self basicCachedHomeAt: cp.
		self basicCachedHomeAt: cp put: (self remap: tmp).
	].
	tmp _ self basicCachedReceiverAt: cp.
	(self isIntegerObject: tmp) ifFalse: [self basicCachedReceiverAt: cp put: (self remap: tmp)].
	tmp _ self basicCachedTranslatedMethodAt: cp.
	ip _ self basicCachedInstructionPointerAt: cp.
	ip _ ip - tmp.
	meth _ self remap: tmp.
	ip _ ip + meth.
	self basicCachedInstructionPointerAt: cp put: ip.
	self basicCachedTranslatedMethodAt: cp put: meth.
	tmp _ self basicCachedMethodAt: cp.
	self basicCachedMethodAt: cp put: (self remap: tmp).
	tmp _ self basicCachedPseudoContextAt: cp.
	(tmp = 0) ifFalse: [self basicCachedPseudoContextAt: cp put: (self remap: tmp)].
	"Map the stack"
	start _ self cachedFramePointerAt: cp.
	limit _ self cachedStackPointerAt: cp.
	start to: limit by: 4 do: [ :ptr |
		tmp _ self longAt: ptr.
		(self isIntegerObject: tmp) ifFalse: [self longAt: ptr put: (self remap: tmp)].
	].