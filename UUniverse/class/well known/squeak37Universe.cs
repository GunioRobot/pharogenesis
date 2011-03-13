squeak37Universe 
	"[UUniverse switchSystemToUniverse: UUniverse squeak37Universe]"
	^UStandardUniverse new
		serverName: 'universes.dnsalias.net';
		serverPort: UUniverseMultiServer defaultPort;
		shortName: 'squeak37';
		description: 'Squeak 3.7';
		packagesURL: 'http://universes.dnsalias.net/~universes/repositories/squeak37.packages' asUrl;
		yourself