primitiveSocketSendDataBufCount

	| count startIndex array s byteSize arrayBase bufStart bytesSent |
	self var: #s declareC: 'SocketPtr s'.

	count		_ self stackIntegerValue: 0.
	startIndex	_ self stackIntegerValue: 1.
	array		_ self stackValue: 2.
	s			_ self socketValueOf: (self stackValue: 3).

	"buffer can be any indexable words or bytes object except CompiledMethod"
	self success: (self isWordsOrBytes: array).

	(self isWords: array)
		ifTrue: [byteSize _ 4]
		ifFalse: [byteSize _ 1].
	self success: (
		(startIndex >= 1) and:
		[(count >= 0) and:
		[(startIndex + count - 1) <= (self lengthOf: array)]]).
	successFlag ifTrue: [
		"Note: adjust bufStart for zero-origin indexing"
		arrayBase _ array + BaseHeaderSize.
		bufStart _ arrayBase + ((startIndex - 1) * byteSize).
		bytesSent _
			self sqSocket: s
				SendDataBuf: bufStart
				Count: (count * byteSize).
	].
	successFlag ifTrue: [
		self pop: 5.  "pop rcvr, s, array, startIndex, count"
		self pushInteger: bytesSent // byteSize.  "push # of elements"
	].