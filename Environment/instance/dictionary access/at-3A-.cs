at: key
	"Compatibility hack for starting up Environments"
	^ self atOrBelow: key ifAbsent: [self errorKeyNotFound]