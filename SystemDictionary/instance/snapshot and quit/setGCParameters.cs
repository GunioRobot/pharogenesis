setGCParameters
	"Adjust the VM's default GC parameters to avoid premature tenuring."

	SmalltalkImage current  vmParameterAt: 5 put: 4000.  "do an incremental GC after this many allocations"
	SmalltalkImage current  vmParameterAt: 6 put: 2000.  "tenure when more than this many objects survive the GC"
	  Smalltalk setGCBiasToGrowGCLimit: 16*1024*1024.
       Smalltalk setGCBiasToGrow: 1.
