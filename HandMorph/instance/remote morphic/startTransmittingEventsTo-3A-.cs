startTransmittingEventsTo: addr
	"Attempt to broadcast events from this hand to a remote hand on the host with the given address. This method just creates the new socket and initiates a connection; it does not wait for the other end to answer."

	| sock |
	remoteConnections do: [:pair |
		sock _ pair first.
		(sock isConnected and: [sock remoteAddress = addr])
			ifTrue: [^ self]].  "don't connect if already connected to the given address"
	Transcript
		show: 'Connecting to remote WorldMorph at ';
		show: (NetNameResolver stringFromAddress: addr), ' ...'; cr.
	sock _ SimpleClientSocket new.
	sock connectTo: addr port: 54323.
	remoteConnections add: (Array with: sock with: #opening with: addr).
