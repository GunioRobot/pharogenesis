setUp
	listener _ Socket createIfFail: [].
	listener _ Socket newTCP listenOn: 7357.
	stream1 _ SocketStream on: (Socket newTCP connectTo: NetNameResolver localHostAddress port: 7357).
	stream2 _ SocketStream on: listener accept