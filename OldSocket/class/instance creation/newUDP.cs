newUDP
	"Create a socket and initialise it for UDP"
	^[ super new initialize: UDPSocketType ]
		repeatWithGCIf: [ :socket | socket isValid not ]