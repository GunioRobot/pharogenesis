homeMoviesUniverse 
	"[UUniverse switchSystemToUniverse: UUniverse homeMoviesUniverse]"
	^UStandardUniverse new
		shortName: 'homemovies';
		serverName: 'universes.dnsalias.net';
		serverPort: UUniverseMultiServer defaultPort;
		packagesURL: 'http://universes.dnsalias.net/~universes/repositories/homemovies.packages' asUrl;
		description: 'Home Movies';
		yourself