mutateToBlockContext: aContext
	"Change the class of aContext to BlockContext"

	self inline: true.
	self assertIsPseudoContext: aContext.
	self changeClassOf: aContext to: (self splObj: ClassBlockContext)