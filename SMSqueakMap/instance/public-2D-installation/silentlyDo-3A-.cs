silentlyDo: aBlock
	"Execute <aBlock> with the Silent flag set.
	This is a crude way of avoiding user interaction
	during batch operations, like loading updates."

	[silent _ true.
	aBlock value]
		ensure: [silent _ nil]