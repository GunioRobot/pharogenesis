openConnectionToHost: hostIP port: portNumber
	| socket |
	socket _ Socket new.
	socket connectTo: hostIP port: portNumber.
	^self on: socket