validateRefStreamOnDisk
	"array is set up with an array."
	| other filename |

	filename _ 'bitmapStreamTest.ref'.
	FileDirectory default deleteFileNamed: filename ifAbsent: [ ].

	stream _ ReferenceStream fileNamed: filename.
	stream nextPut: array; close.

	stream _ ReferenceStream fileNamed: filename.
	other _ stream next.
	stream close.

	self assert: array = other