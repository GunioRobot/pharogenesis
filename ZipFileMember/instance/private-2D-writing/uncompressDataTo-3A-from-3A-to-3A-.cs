uncompressDataTo: aStream from: start to: finish

	| decoder buffer chunkSize |
	decoder _ FastInflateStream on: stream.
	readDataRemaining _ readDataRemaining min: finish - start + 1.
	buffer _ ByteArray new: (32768 min: readDataRemaining).
	decoder next: start - 1.

	[ readDataRemaining > 0 ] whileTrue: [
		chunkSize _ 32768 min: readDataRemaining.
		buffer _ decoder next: chunkSize into: buffer startingAt: 1.
		aStream next: chunkSize putAll: buffer startingAt: 1.
		readDataRemaining _ readDataRemaining - chunkSize.
	].
