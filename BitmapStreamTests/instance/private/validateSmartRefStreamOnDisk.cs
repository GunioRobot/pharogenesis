validateSmartRefStreamOnDisk
	"array is set up with an array."
	| other filename |

	filename _ 'bitmapStreamTest.ref'.
	FileDirectory default deleteFileNamed: filename ifAbsent: [ ].

	stream _ FileDirectory default fileNamed: filename.
	stream fileOutClass: nil andObject: array.
	stream close.

	stream _ FileDirectory default fileNamed: filename.
	other _ stream fileInObjectAndCode.
	stream close.

	self assert: array = other