longPrintOn: stream

	| ctxt |
	super printOn: stream.
	stream cr.
	ctxt _ self suspendedContext.
	[ctxt == nil] whileFalse: [
		stream space.
		ctxt printOn: stream.
		stream cr.
		ctxt _ ctxt sender.
	].
