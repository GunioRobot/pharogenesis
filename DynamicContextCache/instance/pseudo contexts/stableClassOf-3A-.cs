stableClassOf: pc
	"Answer the class needed to represent a stable version of the PseudoContext pc."

	| cp |
	self inline: true.
	self assertIsPseudoContext: pc.
	cp _ self pseudoCachedContextAt: pc.
	(self isCachedBlockContext: cp)
		ifTrue: [^self splObj: ClassBlockContext]
		ifFalse: [^self splObj: ClassMethodContext]