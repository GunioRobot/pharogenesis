pingPorts: portList on: hostName timeOutSecs: timeOutSecs 
	"Attempt to connect to each of the given sockets on the given host. Wait at most timeOutSecs for the connections to be established. Answer an array of strings indicating the available ports."

	"Socket pingPorts: #(7 13 19 21 23 25 80 110 119) on: 'squeak.cs.uiuc.edu' timeOutSecs: 15"

	| serverAddr sockets sock deadline done unconnectedCount connectedCount waitingCount result |
	self initializeNetwork.
	serverAddr := NetNameResolver addressForName: hostName timeout: 10.
	serverAddr = nil 
		ifTrue: 
			[self inform: 'Could not find an address for ' , hostName.
			^#()].
	sockets := portList collect: 
					[:portNum | 
					sock := self new.
					sock connectTo: serverAddr port: portNum].
	deadline := self deadlineSecs: timeOutSecs.
	done := false.
	[done] whileFalse: 
			[unconnectedCount := 0.
			connectedCount := 0.
			waitingCount := 0.
			sockets do: 
					[:s | 
					s isUnconnectedOrInvalid 
						ifTrue: [unconnectedCount := unconnectedCount + 1]
						ifFalse: 
							[s isConnected ifTrue: [connectedCount := connectedCount + 1].
							s isWaitingForConnection ifTrue: [waitingCount := waitingCount + 1]]].
			waitingCount = 0 ifTrue: [done := true].
			connectedCount = sockets size ifTrue: [done := true].
			Time millisecondClockValue > deadline ifTrue: [done := true]].
	result := (sockets select: [:s | s isConnected]) 
				collect: [:s | self nameForWellKnownTCPPort: s remotePort].
	sockets do: [:s | s destroy].
	^result