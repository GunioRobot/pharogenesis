newTCP
	"Create a socket and initialise it for TCP"
	^[ super new initialize: TCPSocketType ]
		repeatWithGCIf: [ :socket | socket isValid not ]