validateRefStream
	"array is set up with an array."
	| other rwstream |
	rwstream _ RWBinaryOrTextStream on: (ByteArray new: array basicSize * 6).

	stream _ ReferenceStream on: rwstream.
	stream nextPut: array; close.

	rwstream position: 0.
	stream _ ReferenceStream on: rwstream.
	other _ stream next.
	stream close.

	self assert: array = other