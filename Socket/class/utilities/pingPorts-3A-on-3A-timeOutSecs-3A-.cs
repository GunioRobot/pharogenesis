pingPorts: portList on: hostName timeOutSecs: timeOutSecs
	"Attempt to connect to each of the given sockets on the given host. Wait at most timeOutSecs for the connections to be established. Answer an array of strings indicating the available ports."
	"Socket pingPorts: #(7 13 19 21 23 25 80 110 119) on: 'squeak.cs.uiuc.edu' timeOutSecs: 15"

	| serverAddr sockets sock deadline done unconnectedCount connectedCount waitingCount result |
	Socket initializeNetwork.
	serverAddr _ NetNameResolver addressForName: hostName timeout: 10.
	serverAddr = nil ifTrue: [
		self inform: 'Could not find an address for ', hostName.
		^ #()].

	sockets _ portList collect: [:portNum |
		sock _ Socket new.
		sock connectTo: serverAddr port: portNum].

	deadline _ self deadlineSecs: timeOutSecs.
	done _ false.
	[done] whileFalse: [
		unconnectedCount _ 0.
		connectedCount _ 0.
		waitingCount _ 0.
		sockets do: [:s |
			s isUnconnectedOrInvalid
				ifTrue: [unconnectedCount _ unconnectedCount + 1]
				ifFalse: [
					s isConnected ifTrue: [connectedCount _ connectedCount + 1].
					s isWaitingForConnection ifTrue: [waitingCount _ waitingCount + 1]]].
		waitingCount = 0 ifTrue: [done _ true].
		connectedCount = sockets size ifTrue: [done _ true].
		Time millisecondClockValue > deadline ifTrue: [done _ true]].

	result _ (sockets select: [:s | s isConnected])
		collect: [:s | self nameForWellKnownTCPPort: s remotePort].
	sockets do: [:s | s destroy].
	^ result
