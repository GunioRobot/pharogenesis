insertSender: aContext
	"Insert aContext and its sender chain between me and my sender.  Return new callee of my original sender."

	| ctxt |
	ctxt _ aContext bottomContext.
	ctxt privSender: self sender.
	self privSender: aContext.
	^ ctxt