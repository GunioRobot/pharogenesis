writeFileHeader
	file position: 0.  "info in header page"
	self write4Bytes: ($A asciiValue *100) + 2.  "version number:  6500+2"
	self write4Bytes: imageHeaderSize.  "File offset (bytes) of start of data"
							"same as base address (byte) of first object"
	self write4Bytes: maxOop.  "Length of data segment in words"
	self write4Bytes: 0.		"what you have to add to an oop to get"
							"an offset in the data portion of this file"
	self write4Bytes: (self mapAt: specialObjects).
	self write4Bytes: (hashGenerator next * 16rFFF asFloat) asInteger.  "next hash"
	self write4Bytes: Display width * 16r10000 + Display height.  "display size"
	file position > imageHeaderSize ifTrue: [self error: 'Header ran over allotted length'].
	file padTo: imageHeaderSize put: 0.  "Pad header page"
	file setType: 'STim' creator: 'FAST'; close