methodString
	| stream |
	stream _ WriteStream on: ''.
	self methodPrintOn: stream.
	^ stream contents