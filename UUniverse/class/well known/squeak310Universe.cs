squeak310Universe 
	"[UUniverse switchSystemToUniverse: UUniverse squeak310Universe]"
	^UStandardUniverse new
		serverName: 'universes.dnsalias.net';
		serverPort: UUniverseMultiServer defaultPort;
		shortName: 'squeak3.10';
		description: 'Squeak 3.10';
		packagesURL: 'http://universes.dnsalias.net/~universes/repositories/squeak3.10.packages' asUrl;
		yourself