mailFrom: fromAddress
	self sendCommand: 'MAIL FROM: <', fromAddress, '>'.
	self checkSMTPResponse.