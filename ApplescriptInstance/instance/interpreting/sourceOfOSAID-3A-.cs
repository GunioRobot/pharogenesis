sourceOfOSAID: anOSAID

	| anAEDesc result |
	anAEDesc _ AEDesc new.
	result _ self primOSAGetSource: anOSAID type: 'TEXT' to: anAEDesc.
	anOSAID disposeWith: self.
	result isZero ifFalse: [^''].
	^anAEDesc asStringThenDispose
	
	