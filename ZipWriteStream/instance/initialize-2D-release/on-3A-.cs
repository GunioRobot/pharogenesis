on: aCollectionOrStream
	crc _ 16rFFFFFFFF.
	crcPosition _ 1.
	bytesWritten _ 0.
	encoder _ ZipEncoder on: aCollectionOrStream.
	encoder isBinary
		ifTrue:[super on: ByteArray new]
		ifFalse:[super on: String new].
	self writeHeader.
