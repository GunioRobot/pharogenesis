method: doit context: ctxt encoder: encoderToUse
	" pattern [ | temporaries ] block => MethodNode."

	| sap blk prim temps messageComment methodNode |
	encoder _ encoderToUse.
	sap _ self pattern: doit inContext: ctxt.
	"sap={selector, arguments, precedence}"
	(sap at: 2) do: [:argNode | argNode isArg: true].
	temps _ self temporariesIn: (sap at: 1).
	messageComment _ currentComment.
	currentComment _ nil.
	prim _ doit ifTrue: [0] ifFalse: [self primitive].
	self statements: #() innerBlock: doit.
	blk _ parseNode.
	doit ifTrue: [blk returnLast]
		ifFalse: [blk returnSelfIfNoOther].
	hereType == #doIt ifFalse: [^self expected: 'Nothing more'].
	self interactive ifTrue: [self removeUnusedTemps].
	methodNode _ self newMethodNode comment: messageComment.
	^ methodNode
		selector: (sap at: 1)
		arguments: (sap at: 2)
		precedence: (sap at: 3)
		temporaries: temps
		block: blk
		encoder: encoder
		primitive: prim