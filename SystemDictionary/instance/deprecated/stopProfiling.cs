stopProfiling
	"Stop profiling the virtual machine."

	^self deprecated: 'Use SmalltalkImage current stopProfiling'
		block: [SmalltalkImage current stopProfiling]