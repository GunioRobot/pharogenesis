flush
	self isOtherEndConnected
		ifTrue: [self socket sendData: self outStream contents].
	self resetOutStream