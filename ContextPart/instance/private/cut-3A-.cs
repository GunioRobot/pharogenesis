cut: aContext
	"Cut aContext and its senders from my sender chain"

	| ctxt callee |
	ctxt _ self.
	[ctxt == aContext] whileFalse: [
		callee _ ctxt.
		ctxt _ ctxt sender.
		ctxt ifNil: [aContext ifNotNil: [self error: 'aContext not a sender']].
	].
	callee privSender: nil.
