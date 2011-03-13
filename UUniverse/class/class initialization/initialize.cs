initialize
	"fix up old instances, to have a proper packagesURL"
	"this method should be deleted, after suitable time has passed to allow for upgrades"

	self allSubInstancesDo: [ :universe |
		universe class == UStandardUniverse ifTrue: [
			universe packagesURL == nil ifTrue: [
				"no URL specified.  guess...."
				universe serverPort = 4129 ifTrue: [
					universe shortName: 'development'.
					universe packagesURL: 'http://universes.dnsalias.net:8888/~universes/repositories/development.packages' asUrl.
					universe serverPort: UUniverseMultiServer defaultPort. ].
				universe serverPort = 8940 ifTrue: [ 
					universe shortName: 'homevideos'.
					universe packagesURL: 'http://universes.dnsalias.net:8888/~universes/repositories/homemovies.packages' asUrl.
					universe serverPort: UUniverseMultiServer defaultPort. ].
				universe serverPort = 7273 ifTrue: [ 
					universe shortName: 'squeak37'.
					universe packagesURL: 'http://universes.dnsalias.net:8888/~universes/repositories/squeak37.packages' asUrl.
					universe serverPort: UUniverseMultiServer defaultPort. ]. ] ] ]