rcvrExtraPtrFrom: aByteArrayOrNilObject

	self inline: true.
	interpreterProxy 
		storePointer: 3 
		ofObject: rcvr 
		withValue: aByteArrayOrNilObject