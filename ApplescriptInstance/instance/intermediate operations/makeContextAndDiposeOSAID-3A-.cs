makeContextAndDiposeOSAID: anOSAID
	
	| result contextOSAID contextAEDesc |
	contextOSAID _ OSAID new.
	result _ self 
		primOSAMakeContext: (AEDesc nullType)
		parent: anOSAID
		to: contextOSAID.
	anOSAID dispose.
	result isZero ifFalse: [^nil].
	contextAEDesc _ self storeAndDisposeOSAID: contextOSAID type: 'scpt' mode: 0.
	contextAEDesc ifNil: [^nil].
	^ contextAEDesc asCompiledApplescriptThenDispose