doubleExtendedDoAnythingBytecode
	"Replaces the Blue Book double-extended send [132], in which
	the first byte was wasted on 8 bits of argument count.
	Here we use 3 bits for the operation sub-type (opType),
	and the remaining 5 bits for argument count where needed.
	The last byte give access to 256 instVars or literals.
	See also secondExtendedSendBytecode"

	| byte2 byte3 opType top |
	byte2 _ self fetchByte.
	byte3 _ self fetchByte.
	opType _ byte2 >> 5.
	opType = 0 ifTrue: [
		messageSelector _ self literal: byte3.
		argumentCount _ byte2 bitAnd: 16r1F.
		^ self normalSend
	].
	opType = 1 ifTrue: [
		messageSelector _ self literal: byte3.
		argumentCount _ byte2 bitAnd: 16r1F.
		^ self superclassSend
	].
	self fetchNextBytecode.
	opType = 2 ifTrue: [^ self pushReceiverVariable: byte3].
	opType = 3 ifTrue: [^ self pushLiteralConstant: byte3].
	opType = 4 ifTrue: [^ self pushLiteralVariable: byte3].
	opType = 5 ifTrue: [
		top _ self internalStackTop.
		^ self storePointer: byte3 ofObject: receiver withValue: top
	].
	opType = 6 ifTrue: [
		top _ self internalStackTop.
		self internalPop: 1.
		^ self storePointer: byte3 ofObject: receiver withValue: top
	].
	opType = 7 ifTrue: [
		top _ self internalStackTop.
		^ self storePointer: ValueIndex ofObject: (self literal: byte3) withValue: top
	].