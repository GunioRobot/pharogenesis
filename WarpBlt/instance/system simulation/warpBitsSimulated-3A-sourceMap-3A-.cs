warpBitsSimulated: n sourceMap: sourceMap
	"Simulate WarpBlt"
	Smalltalk at: #BitBltSimulation ifPresent:[:bb| bb warpBitsFrom: self].