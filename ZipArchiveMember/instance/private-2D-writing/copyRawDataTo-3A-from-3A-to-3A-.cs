copyRawDataTo: aStream from: start to: finish

	readDataRemaining _ readDataRemaining min: finish - start + 1.

	self readRawChunk: start - 1.

	[ readDataRemaining > 0 ] whileTrue: [ | data |
		data _ self readRawChunk: (32768 min: readDataRemaining).
		aStream nextPutAll: data.
		readDataRemaining _ readDataRemaining - data size.
	].
