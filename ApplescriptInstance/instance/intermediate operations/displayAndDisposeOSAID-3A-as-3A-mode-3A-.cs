displayAndDisposeOSAID: anOSAID as: aString mode: anInteger

	| anAEDesc result |
	anOSAID isEmpty ifTrue: [^AEDesc textTypeOn: ''].
	anAEDesc _ AEDesc new.
	result _ self 
		primOSADisplay: anOSAID 
		as: (DescType of: aString)
		mode: anInteger 
		to: anAEDesc.
	anOSAID disposeWith: self.
	result isZero ifFalse: 
		[^nil].
	^anAEDesc