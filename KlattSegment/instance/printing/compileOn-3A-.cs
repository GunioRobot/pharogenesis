compileOn: aClass
	| stream |
	stream _ WriteStream on: ''.
	self methodPrintOn: stream.
	aClass compile: stream contents classified: 'default segments'