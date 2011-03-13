betaUniverse 
	"[UUniverse switchSystemToUniverse: UUniverse betaUniverse]"
	^UStandardUniverse new
		serverName: 'universes.dnsalias.net';
		serverPort: UUniverseMultiServer defaultPort;
		shortName: 'beta';
		description: 'Beta Development';
		packagesURL: 'http://universes.dnsalias.net/~universes/repositories/beta.packages' asUrl;
		yourself
