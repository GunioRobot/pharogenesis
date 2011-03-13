validateSmartRefStreamOnDisk
	"array is set up with an array."
	| other  |

	FileDirectory default deleteFileNamed: filename ifAbsent: [ ].

	stream := FileDirectory default fileNamed: filename.
	stream fileOutClass: nil andObject: array.
	stream close.

	stream := FileDirectory default fileNamed: filename.
	other := stream fileInObjectAndCode.
	stream close.

	self assert: array = other