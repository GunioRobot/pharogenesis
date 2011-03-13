connectTo: aSocketAddress waitForConnectionFor: timeout 

	self connectNonBlockingTo: aSocketAddress.
	self
		waitForConnectionFor: timeout
		ifTimedOut: [ConnectionTimedOut signal: 'Cannot connect to ', aSocketAddress printString]