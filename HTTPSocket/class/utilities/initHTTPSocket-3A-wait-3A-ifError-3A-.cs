initHTTPSocket: httpUrl wait: timeout ifError: aBlock
	"Retrieve the server and port information from the URL, match it to the proxy settings and open a http socket for the request."

	| serverName port serverAddr s |
	Socket initializeNetwork.

	serverName _ httpUrl authority.
	port _ httpUrl port ifNil: [self defaultPort].

	(self shouldUseProxy: serverName) ifTrue: [ 
		serverName _ HTTPProxyServer.
		port _ HTTPProxyPort].

  	"make the request"	
	serverAddr _ NetNameResolver addressForName: serverName timeout: 20.
	serverAddr ifNil: [
		aBlock value: 'Error: Could not resolve the server named: ', serverName].

	s _ HTTPSocket new.
	s connectTo: serverAddr port: port.
	(s waitForConnectionUntil: timeout) ifFalse: [
		Socket deadServer: httpUrl authority.
		s destroy.
		^aBlock value: 'Error: Server ',httpUrl authority,' is not responding'].
	^s
