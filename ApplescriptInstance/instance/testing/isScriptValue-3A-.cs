isScriptValue: anOSAID

	| result |
	result _ IntegerArray new: 1.
	(self 
		primOSAGetScriptInfo: anOSAID 
		type: (DescType of: 'valu')
		to: result) isZero ifFalse: [^nil].
	^(result at: 1) > 0