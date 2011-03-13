methodString
	| stream |
	stream := WriteStream on: ''.
	self methodPrintOn: stream.
	^ stream contents