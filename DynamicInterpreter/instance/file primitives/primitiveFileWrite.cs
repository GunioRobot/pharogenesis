primitiveFileWrite

	| count startIndex array file byteSize arrayIndex bytesWritten |
	self var: 'file' declareC: 'SQFile *file'.

	count		_ self stackIntegerValue: 0.
	startIndex	_ self stackIntegerValue: 1.
	array		_ self stackValue: 2.
	file			_ self fileValueOf: (self stackValue: 3).

	"buffer can be any indexable words or bytes object except CompiledMethod"
	self success: (self isWordsOrBytes: array).

	(self isWords: array)
		ifTrue: [ byteSize _ 4 ]
		ifFalse: [ byteSize _ 1 ].
	self success: (
		(startIndex >= 1) and:
		[(startIndex + count - 1) <= (self lengthOf: array)]).
	successFlag ifTrue: [
		arrayIndex _ array + BaseHeaderSize.
		"Note: adjust startIndex for zero-origin indexing"
		bytesWritten _
			self sqFile: file
				Write: (count * byteSize)
				From: arrayIndex At: ((startIndex - 1) * byteSize).
	].
	successFlag ifTrue: [
		self pop: 5.  "pop rcvr, file, array, startIndex, count"
		self pushInteger: bytesWritten // byteSize.  "push # of elements written"
	].