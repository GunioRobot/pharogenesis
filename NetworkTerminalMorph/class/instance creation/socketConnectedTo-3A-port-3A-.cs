socketConnectedTo: serverHost  port: serverPort

	| sock |

	Socket initializeNetwork.
	sock _ Socket new.
	sock connectTo: (NetNameResolver addressForName: serverHost) port: serverPort.
	sock waitForConnectionUntil: Socket standardDeadline.
	sock isConnected ifFalse: [ self error: 'could not connect to server' ].
	^StringSocket on: sock

