parse: sourceStream class: class noPattern: noPattern context: ctxt notifying: req ifFail: aBlock 
	"Answer a MethodNode for the argument, sourceStream, that is the root of 
	a parse tree. Parsing is done with respect to the argument, class, to find 
	instance, class, and pool variables; and with respect to the argument, 
	ctxt, to find temporary variables. Errors in parsing are reported to the 
	argument, req, if not nil; otherwise aBlock is evaluated. The argument 
	noPattern is a Boolean that is true if the the sourceStream does not 
	contain a method header (i.e., for DoIts)."

	 | meth |
	self init: sourceStream notifying: req failBlock: [^aBlock value].
	encoder _ Encoder new init: class context: ctxt notifying: self.
	failBlock_ aBlock.
	meth _ self method: noPattern context: ctxt.
	encoder _ failBlock _ requestor _ parseNode _ nil. "break cycles & mitigate refct overflow"
	^meth