pushReceiverVariable: fieldIndex

	self internalPush:
		(self fetchPointer: fieldIndex ofObject: receiver).