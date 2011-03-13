compileOn: aClass
	| stream |
	stream := WriteStream on: ''.
	self methodPrintOn: stream.
	aClass compile: stream contents classified: 'default segments'