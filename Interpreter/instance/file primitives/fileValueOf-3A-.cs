fileValueOf: objectPointer
	"Return a pointer to the first byte of of the file record within the given Smalltalk object, or nil if objectPointer is not a file record."

	| fileIndex |
	self returnTypeC: 'SQFile *'.
	self success:
		((self isBytes: objectPointer) and:
		 [(self lengthOf: objectPointer) = self fileRecordSize]).

	successFlag ifTrue: [
		fileIndex _ objectPointer + BaseHeaderSize.
		^ self cCode: '(SQFile *) fileIndex'
	] ifFalse:  [
		^ nil
	].