openDataSocket: remoteHostAddress port: dataPort
	dataSocket _ Socket new.
	dataSocket connectTo: remoteHostAddress port: dataPort