on: aCollectionOrStream
	encoder _ ZipEncoder on: aCollectionOrStream.
	encoder isBinary
		ifTrue:[super on: ByteArray new]
		ifFalse:[super on: String new]