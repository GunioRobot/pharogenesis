compile: aString mode: anInteger

	| sourceAEDesc objectOSAID objectAEDesc |
	sourceAEDesc _ AEDesc textTypeOn: aString.
	(objectOSAID _ self 
		compileAndDisposeAEDesc: sourceAEDesc 
		mode: anInteger) ifNil: [^nil].
	(objectAEDesc _ self 
		storeAndDisposeOSAID: objectOSAID 
		type: 'scpt' 
		mode: anInteger) ifNil: [^nil].
	^objectAEDesc asCompiledApplescriptThenDispose
