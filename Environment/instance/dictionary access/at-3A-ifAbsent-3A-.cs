at: key ifAbsent: aBlock
	"Compatibility hack for starting up Environments"
	^ self atOrBelow: key ifAbsent: aBlock