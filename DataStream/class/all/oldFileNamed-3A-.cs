oldFileNamed: aString
	"Here is the way to use DataStream and ReferenceStream:
rr _ ReferenceStream oldFileNamed: 'test.obj'.
^ rr nextAndClose.
"

	| strm ff |
	ff _ FileStream oldFileOrNoneNamed: aString.
	ff ifNil: [^ nil].
	strm _ self on: (ff binary).
	^ strm