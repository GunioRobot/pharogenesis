loadAndDisposeAEDesc: anAEDesc mode: anInteger

	| anOSAID result |
	anOSAID _ OSAID new.
	result _ self primOSALoad: anAEDesc mode: anInteger to: anOSAID.
	anAEDesc dispose.
	result isZero ifFalse: [^nil].
	^anOSAID