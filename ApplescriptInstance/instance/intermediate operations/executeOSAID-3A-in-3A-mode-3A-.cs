executeOSAID: sourceOSAID in: contextOSAID mode: anInteger

	| objectOSAID result |
	objectOSAID _ OSAID new.
	result _ self 
		primOSAExecute: sourceOSAID 
		in: contextOSAID
		mode: anInteger 
		to: objectOSAID.
	result isZero ifFalse: [^nil].
	^objectOSAID