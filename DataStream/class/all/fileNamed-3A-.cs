fileNamed: aString
	"Here is the way to use DataStream and ReferenceStream:
rr _ ReferenceStream fileNamed: 'test.obj'.
rr nextPut: <your object>.
rr close.
"

	| strm |
	strm _ self on: (FileStream fileNamed: aString).		"will be binary"
	strm byteStream setFileTypeToObject.
		"Type and Creator not to be text, so can attach correctly to an email msg"
	^ strm