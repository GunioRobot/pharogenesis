returnNil

	| cntx val |
	cntx _ self sender.
	val _ nilObj.
	self returnValue: val to: cntx.
