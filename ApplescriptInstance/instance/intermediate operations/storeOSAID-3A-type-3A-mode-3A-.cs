storeOSAID: anOSAID type: aString mode: anInteger

	| theAEDesc result |
	theAEDesc _ AEDesc new.
	result _ self	
		primOSAStore: anOSAID 
		resultType: (DescType of: aString) 
		mode: 0  to: (theAEDesc).
	result isZero ifFalse: [^nil].
	^theAEDesc

