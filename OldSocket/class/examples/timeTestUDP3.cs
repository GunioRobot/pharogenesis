timeTestUDP3
	"Socket timeTestUDP3"

	| serverName serverAddr s |
	Transcript show: 'initializing network ... '.
	self initializeNetworkIfFail: [^Transcript show: 'failed'].
	Transcript
		show: 'ok';
		cr.
	serverName := FillInTheBlank request: 'What is your time server?'
				initialAnswer: 'localhost'.
	serverName isEmpty 
		ifTrue: 
			[^Transcript
				show: 'never mind';
				cr].
	serverAddr := NetNameResolver addressForName: serverName timeout: 10.
	serverAddr = nil 
		ifTrue: [self error: 'Could not find the address for ' , serverName].
	s := self newUDP.
	"The following associates a port with the UDP socket, but does NOT create a connectable endpoint"
	s setPort: self wildcardPort.	"explicitly request a default port number"
	"Send a packet to the daytime port and it will reply with the current date."
	Transcript
		show: '---------- Sending datagram from port ' , s port printString 
					, ' ----------';
		cr.
	s 
		sendData: '!'
		toHost: serverAddr
		port: 13.
	Transcript show: 'the time server reports: ' , s getResponseNoLF.
	s closeAndDestroy.
	Transcript
		show: '---------- Socket closed ----------';
		cr