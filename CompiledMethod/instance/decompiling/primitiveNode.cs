primitiveNode

	| primNode n |
	primNode _ PrimitiveNode new num: (n _ self primitive).
	(n = 117 or: [n = 120]) ifTrue: [
		primNode spec: (self literalAt: 1)].
	^ primNode