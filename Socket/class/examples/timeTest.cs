timeTest
	"Socket timeTest"

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

	s _ Socket new.
	Transcript show: '---------- Connecting ----------'; cr.
	s connectTo: serverAddr port: 13.  "13 is the 'daytime' port number"
	s waitForConnectionUntil: (self deadlineSecs: 1).
	Transcript show: 'the time server reports: ' , s getResponseNoLF.
	s closeAndDestroy.
	Transcript show: '---------- Connection Closed ----------'; cr.
