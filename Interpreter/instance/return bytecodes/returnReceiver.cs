returnReceiver

	| cntx val |
	cntx _ self sender.
	val _ receiver.
	self returnValue: val to: cntx.