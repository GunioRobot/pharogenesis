initialize
	"Socket initialize"

	"Socket Types"
	TCPSocketType _ 0.
	UDPSocketType _ 1.

	"Socket Status Values"
	InvalidSocket _ -1.
	Unconnected _ 0.
	WaitingForConnection _ 1.
	Connected _ 2.
	OtherEndClosed _ 3.
	ThisEndClosed _ 4.
