validateRefStreamOnDisk
	"array is set up with an array."
	| other filename |

	filename := 'bitmapStreamTest.ref'.
	FileDirectory default deleteFileNamed: filename ifAbsent: [ ].

	stream := ReferenceStream fileNamed: filename.
	stream nextPut: array; close.

	stream := ReferenceStream fileNamed: filename.
	other := stream next.
	stream close.

	self assert: array = other