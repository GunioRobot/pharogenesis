guessDOLProxy
	"Decide if we need to go through the DOL proxy server to reach the EToy servers, and set the HTTPSocket proxy server appropriately."

	| addr s |
	Socket initializeNetwork.
	"try several times with increasing timeout values"
	#(10 20 40 80) do: [:seconds |
		"can we see the DOL proxy server?"
		addr _ NetNameResolver addressForName: 'web-proxy.online.disney.com' timeout: seconds.
		addr ifNotNil: [
			HTTPSocket useProxyServerNamed: 'web-proxy.online.disney.com' port: 8080.
			^ self].

		"can we connect to an EToy server?"
		self serverUrls do: [:serverName |
			addr _ NetNameResolver addressForName: (serverName copyUpTo: $/) timeout: seconds.
			addr ifNotNil: [
				s _ HTTPSocket new.
				s connectTo: addr port: 80.
				s waitForConnectionUntil: (Socket deadlineSecs: seconds).
				s isConnected ifTrue: [
					s destroy.
					HTTPSocket stopUsingProxyServer.
					^ self].
				s destroy]]].
