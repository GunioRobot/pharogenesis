connect
	"connect to the name host"
	| addr |
	self isConnected ifTrue: [ self disconnect ].

	Socket initializeNetwork.

	addr _ NetNameResolver addressForName: hostname.
	addr ifNil: [ self error: 'could not find address for ', hostname ].

	socket _ Socket new.
	
	socket connectTo: addr port: port.
	(socket waitForConnectionUntil: Socket standardDeadline) ifFalse: [
		self error: 'connection failed' ].

	
	requestedRemoteEcho _ true.
	self do: OPTEcho.