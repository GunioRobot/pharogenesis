initialize
	"HTTPLoader initialize"

	MaxNrOfConnections _ 2.
	DefaultLoader ifNotNil: [
		DefaultLoader release.
		DefaultLoader _ nil]