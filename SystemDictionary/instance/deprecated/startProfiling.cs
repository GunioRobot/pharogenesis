startProfiling
	"Start profiling the virtual machine."

	^self deprecated: 'Use SmalltalkImage current startProfiling'
		block: [SmalltalkImage current  startProfiling]