sendStreamContents: stream checkBlock: checkBlock
	"Send the data in the stream. Close the stream after you are done. After each block of data evaluate checkBlock and abort if it returns false.
	Usefull for directly sending contents of a file without reading into memory first."

	| chunkSize buffer |
	chunkSize _ 5000.
	buffer _ ByteArray new: chunkSize.
	stream binary.
	[[stream atEnd and: [checkBlock value]]
		whileFalse: [
			buffer _ stream next: chunkSize into: buffer.
			self sendData: buffer]]
		ensure: [stream close]