rcvrPCREBufferFrom: aByteArray

	self inline: true.
	interpreterProxy 
		storePointer: 2 
		ofObject: rcvr 
		withValue: aByteArray