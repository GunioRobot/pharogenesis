returnTrue

	| cntx val |
	cntx _ self sender.
	val _ trueObj.
	self returnValue: val to: cntx.
