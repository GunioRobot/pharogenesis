generateDivide: msgNode on: aStream indent: level
	"Generate the C code for this message onto the given stream."

	| rcvr arg divisor |
	rcvr _ msgNode receiver.
	arg _ msgNode args first.
	(arg isConstant and:
	 [UseRightShiftForDivide and:
	 [(divisor _ arg value) isInteger and:
	 [divisor isPowerOfTwo and:
	 [divisor > 0 and:
	 [divisor <= (1 bitShift: 31)]]]]])
	ifTrue: [
		"use signed (arithmetic) right shift instead of divide"
		aStream nextPutAll: '((int) '.
		self emitCExpression: rcvr on: aStream.
		aStream nextPutAll: ' >> ', (divisor log: 2) asInteger printString.
		aStream nextPutAll: ')'.
	] ifFalse: [
		self emitCExpression: rcvr on: aStream.
		aStream nextPutAll: ' / '.
		self emitCExpression: arg on: aStream].
