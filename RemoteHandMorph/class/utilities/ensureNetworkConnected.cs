ensureNetworkConnected
	"Try to ensure that an intermittent network connection, such as a dialup or ISDN line, is actually connected. This is necessary to make sure a server is visible in order to accept an incoming connection."
	"RemoteHandMorph ensureNetworkConnected"

	Utilities
		informUser: 'Contacting domain name server...'
		during: [
			NetNameResolver
				addressForName: 'squeak.org'
				timeout: 30].
