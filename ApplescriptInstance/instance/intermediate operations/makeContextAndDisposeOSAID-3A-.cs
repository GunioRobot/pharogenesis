makeContextAndDisposeOSAID: anOSAID
	
	| result contextAEDesc |
	contextAEDesc _ AEDesc new.
	result _ self 
		primOSAMakeContext: (AEDesc nullType)
		parent: anOSAID
		to: contextAEDesc.
	result isZero ifFalse: [^nil].
	anOSAID disposeWith: self.
	^ contextAEDesc asCompiledApplescriptThenDispose