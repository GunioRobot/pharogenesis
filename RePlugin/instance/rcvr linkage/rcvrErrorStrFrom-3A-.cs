rcvrErrorStrFrom: aString

	self inline: true.
	interpreterProxy 
		storePointer: 4
		ofObject: rcvr 
		withValue: aString.
