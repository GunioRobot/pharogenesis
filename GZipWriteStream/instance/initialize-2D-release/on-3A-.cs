on: aCollection
	crc _ 16rFFFFFFFF.
	crcPosition _ 1.
	bytesWritten _ 0.
	super on: aCollection.
	self writeHeader.
