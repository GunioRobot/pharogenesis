on: aCollectionOrStream
	aCollectionOrStream isStream 
		ifTrue:[encodedStream _ aCollectionOrStream]
		ifFalse:[	encodedStream _ WriteStream on: aCollectionOrStream].
	encodedStream isBinary
		ifTrue:[super on: (ByteArray new: 4096)]
		ifFalse:[super on: (String new: 4096)].
	bitPosition _ bitBuffer _ 0.