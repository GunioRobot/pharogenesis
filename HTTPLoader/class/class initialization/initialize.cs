initialize
	"HTTPLoader initialize"

	MaxNrOfConnections _ 4.
	DefaultLoader ifNotNil: [
		DefaultLoader release.
		DefaultLoader _ nil]