fileNamed: aString
	"Here is the way to use DataStream and ReferenceStream:
rr _ ReferenceStream fileNamed: 'test.obj'.
rr nextPut: <your object>.
rr close.
"

	^ self on: ((FileStream fileNamed: aString) binary)