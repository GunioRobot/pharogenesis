socketValueOf: socketOop
	"Return a pointer to the first byte of of the socket record within the given Smalltalk object, or nil if socketOop is not a socket record."

	| socketIndex |
	self returnTypeC: 'SQSocket *'.
	self success:
		((self isBytes: socketOop) and:
		 [(self lengthOf: socketOop) = self socketRecordSize]).

	successFlag ifTrue: [
		socketIndex _ socketOop + BaseHeaderSize.
		^ self cCode: '(SQSocket *) socketIndex'
	] ifFalse:  [
		^ nil
	].