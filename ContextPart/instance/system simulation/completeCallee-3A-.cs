completeCallee: aContext
	"Simulate the execution of bytecodes until a return to the receiver."
	| ctxt current ctxt1 |
	ctxt _ aContext.
	[ctxt == current or: [ctxt hasSender: self]]
		whileTrue: 
			[current _ ctxt.
			ctxt1 _ ctxt quickStep.
			ctxt1 ifNil: [self halt].
			ctxt _ ctxt1].
	^self stepToSendOrReturn