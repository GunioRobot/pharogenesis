timeTestUDP
	"Socket timeTestUDP"

	| serverName serverAddr s |
	Transcript show: 'initializing network ... '.
	Socket initializeNetworkIfFail: [^Transcript show:'failed'].
	Transcript show:'ok';cr.
	serverName _ FillInTheBlank
		request: 'What is your time server?'
		initialAnswer: 'localhost'.
	serverName isEmpty ifTrue: [^ Transcript show: 'never mind'; cr].
	serverAddr _ NetNameResolver addressForName: serverName timeout: 10.
	serverAddr = nil ifTrue: [self error: 'Could not find the address for ', serverName].

	s _ Socket newUDP.		"a 'random' port number will be allocated by the system"
	"Send a packet to the daytime port and it will reply with the current date."
	Transcript show: '---------- Sending datagram from port ' , s port printString , ' ----------'; cr.
	s sendData: '!' toHost: serverAddr port: 13.	"13 is the daytime service"
	Transcript show: 'the time server reports: ' , s getResponseNoLF.
	s closeAndDestroy.
	Transcript show: '---------- Socket closed ----------'; cr.
