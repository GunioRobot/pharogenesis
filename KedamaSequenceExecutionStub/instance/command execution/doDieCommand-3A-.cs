doDieCommand: aBlock

	| ret |
	ret _ self doExamplerCommand: aBlock.
	sequentialStub index: index.
	aBlock value: sequentialStub.

	^ ret.

