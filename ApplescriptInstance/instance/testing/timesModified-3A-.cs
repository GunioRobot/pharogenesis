timesModified: anOSAID

	| result |
	result _ IntegerArray new: 1.
	(self 
		primOSAGetScriptInfo: anOSAID 
		type: (DescType of: 'modi')
		to: result) isZero ifFalse: [^nil].
	^result at: 1