completeCallee: aContext
	"Simulate the execution of bytecodes until a return to the receiver."
	| ctxt current |
	ctxt _ aContext.
	[ctxt == current or: [ctxt hasSender: self]]
		whileTrue: 
			[current _ ctxt.
			ctxt _ ctxt step].
	self stepToSendOrReturn