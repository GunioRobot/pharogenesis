squeak39Universe 
	"[UUniverse switchSystemToUniverse: UUniverse squeak39Universe]"
	^UStandardUniverse new
		serverName: 'universes.dnsalias.net';
		serverPort: UUniverseMultiServer defaultPort;
		shortName: 'squeak3.9';
		description: 'Squeak 3.9';
		packagesURL: 'http://universes.dnsalias.net/~universes/repositories/squeak3.9.packages' asUrl;
		yourself