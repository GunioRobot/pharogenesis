cleanupDeadConnections
	"Clean up any remote connections that have been disconnected or become invalid."

	| liveConnections sock |
	liveConnections _ OrderedCollection new.
	remoteConnections do: [:triple |
		sock _ triple first.
		sock isConnected
			ifTrue: [liveConnections add: triple]
			ifFalse: [
				(triple at: 2) = #opening
					ifTrue: [
						Transcript show: 'trying connection again...'; cr.
						sock destroy.
						sock _ Socket new.
						sock connectTo: (triple at: 3) port: 54323.
						triple at: 1 put: sock.
						liveConnections add: triple]  "try again"
					ifFalse: [
						sock isUnconnectedOrInvalid
							ifTrue: [triple first destroy]
							ifFalse: [liveConnections add: triple]]]].  "closing"
	remoteConnections _ liveConnections.
