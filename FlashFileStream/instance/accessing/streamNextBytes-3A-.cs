streamNextBytes: nBytes
	^ FlashFileStream on: (ReadStream
		on: stream contents
		from: stream position + 1
		to: stream position + nBytes).