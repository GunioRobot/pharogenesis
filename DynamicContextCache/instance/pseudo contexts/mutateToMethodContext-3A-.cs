mutateToMethodContext: aContext
	"Change the class of aContext to MethodContext"

	self inline: true.
	self assertIsPseudoContext: aContext.
	self changeClassOf: aContext to: (self splObj: ClassMethodContext)