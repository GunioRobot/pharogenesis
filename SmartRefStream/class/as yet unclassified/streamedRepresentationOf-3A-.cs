streamedRepresentationOf: anObject

	| file |
	file _ (RWBinaryOrTextStream on: (ByteArray new: 5000)).
	file binary.
	(self on: file) nextPut: anObject.
	file close.
	^file contents