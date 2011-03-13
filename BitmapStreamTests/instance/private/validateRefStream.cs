validateRefStream
	"array is set up with an array."
	| other rwstream |
	rwstream := RWBinaryOrTextStream on: (ByteArray new: array basicSize * 6).

	stream := ReferenceStream on: rwstream.
	stream nextPut: array; close.

	rwstream position: 0.
	stream := ReferenceStream on: rwstream.
	other := stream next.
	stream close.

	self assert: array = other