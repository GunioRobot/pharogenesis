rcvrErrorOffsetFrom: anInteger

	self inline: true.
	interpreterProxy storeInteger: 5 ofObject: rcvr withValue: anInteger.
