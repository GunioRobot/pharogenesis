openPassiveDataConnection
	| portInfo list dataPort remoteHostAddress |
	self sendCommand: 'PASV'.
	self lookForCode: 227 ifDifferent: [:response | (TelnetProtocolError protocolInstance: self) signal: 'Could not enter passive mode: ' , response].

	portInfo _ (self lastResponse findTokens: '()') at: 2.
	list _ portInfo findTokens: ','.
	remoteHostAddress _ ByteArray
		with: (list at: 1) asNumber
		with: (list at: 2) asNumber
		with: (list at: 3) asNumber
		with: (list at: 4) asNumber.
	dataPort _ (list at: 5) asNumber * 256 + (list at: 6) asNumber.
	self openDataSocket: remoteHostAddress port: dataPort
