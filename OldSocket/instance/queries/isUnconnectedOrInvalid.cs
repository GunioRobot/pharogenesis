isUnconnectedOrInvalid
	"Return true if this socket is completely disconnected or is invalid."

	| status |
	socketHandle == nil ifTrue: [^ true].
	status _ self primSocketConnectionStatus: socketHandle.
	^ (status = Unconnected) | (status = InvalidSocket)
