compileAndDisposeAEDesc: sourceAEDesc mode: anInteger

	| objectOSAID result |
	objectOSAID _ OSAID new.
	result _ self	
		primOSACompile: sourceAEDesc
		mode: anInteger
		to: objectOSAID.
	sourceAEDesc dispose.
	result isZero ifFalse: [^nil].
	^objectOSAID
