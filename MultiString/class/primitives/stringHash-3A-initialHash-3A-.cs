stringHash: aString initialHash: speciesHash

	aString isOctetString ifTrue: [^ aString asOctetString hash].
	^ self multiStringHash: aString initialHash: speciesHash.
