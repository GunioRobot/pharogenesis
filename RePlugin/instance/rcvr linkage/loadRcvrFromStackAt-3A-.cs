loadRcvrFromStackAt: stackInteger

	self inline:true.
	rcvr _ interpreterProxy stackObjectValue: stackInteger.
