globalIncomingQueueCopy

	^self critical: [self globalIncomingQueue copy].
