setGCParameters
	"Adjust the VM's default GC parameters to avoid premature tenuring."

	Smalltalk vmParameterAt: 5 put: 4000.  "do an incremental GC after this many allocations"
	Smalltalk vmParameterAt: 6 put: 2000.  "tenure when more than this many objects survive the GC"
