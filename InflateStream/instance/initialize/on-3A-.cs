on: aCollectionOrStream
	aCollectionOrStream isStream 
		ifTrue:[	sourceStream _ aCollectionOrStream.
				self getFirstBuffer]
		ifFalse:[source _ aCollectionOrStream].
	^self on: source from: 1 to: source size.