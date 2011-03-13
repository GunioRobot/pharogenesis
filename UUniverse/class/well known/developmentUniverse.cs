developmentUniverse 
	"[UUniverse switchSystemToUniverse: UUniverse developmentUniverse]"
	^UStandardUniverse new
		serverName: 'universes.dnsalias.net';
		serverPort: UUniverseMultiServer defaultPort;
		shortName: 'development';
		description: 'Development';
		packagesURL: 'http://universes.dnsalias.net/~universes/repositories/development.packages' asUrl;
		yourself
