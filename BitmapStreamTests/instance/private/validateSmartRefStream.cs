validateSmartRefStream
	"array is set up with an array."
	| other |
	stream := RWBinaryOrTextStream on: (ByteArray new: array basicSize * 6).
	stream binary.
	stream fileOutClass: nil andObject: array.
	stream position: 0.
	stream binary.
	other := stream fileInObjectAndCode.
	self assert: array = other