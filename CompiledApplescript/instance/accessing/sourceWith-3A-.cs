sourceWith: anApplescriptInstance

	| theOSAID theSource|
	(theOSAID _ self asOSAIDWith: anApplescriptInstance) ifNil: [^''].
	theSource _ anApplescriptInstance sourceOfOSAID: theOSAID.
	theOSAID disposeWith: anApplescriptInstance.
	^theSource ifNil: [^''].